        [HttpPost]
        [Transaction]
        [ValidateInput(false)]
        public ActionResult SendGrid(int attachments, string charsets, string from, string headers, string html, string subject, string envelope, string text, string to, string cc) {
            try {
                StringBuilder logText = new StringBuilder();
                logText.AppendLine("From: " + from);
                logText.AppendLine("Headers: " + headers);
                logText.AppendLine("Text: " + text);
                logText.AppendLine("Html: " + html);
                logText.AppendLine("To: " + to);
                logText.AppendLine("Cc: " + cc);
                logText.AppendLine("Subject: " + subject);
                logText.AppendLine("Attachments: " + attachments);
                //Envelope Json
                Envelope envelopeObject = null;
                if (!string.IsNullOrEmpty(envelope)) {
                    envelopeObject = JsonConvert.DeserializeObject<Envelope>(envelope);
                    if (envelopeObject != null) {
                        logText.AppendLine("Envelope: [from]: " + envelopeObject.From);
                        if (envelopeObject.To != null && envelopeObject.To.Length > 0)
                            foreach (var envelopeTo in envelopeObject.To)
                                logText.AppendLine("Envelope: [To]: " + envelopeTo);
                    }
                }
                //Charsets Json
                CharsetRequest charsetsObject = null;
                if (!string.IsNullOrEmpty(charsets)) {
                    charsetsObject = JsonConvert.DeserializeObject<CharsetRequest>(charsets);
                    if (charsetsObject != null) {
                        logText.AppendLine("Charsets: [To]: " + charsetsObject.To);
                        logText.AppendLine("Charsets: [From]: " + charsetsObject.From);
                        logText.AppendLine("Charsets: [Text]: " + charsetsObject.Text);
                        logText.AppendLine("Charsets: [Subject]: " + charsetsObject.Subject);
                        logText.AppendLine("Charsets: [Html]: " + charsetsObject.Html);
                    }
                }
                List<EmailAttachment> emailAttachments = new List<EmailAttachment>();
                if (attachments > 0) {
                    for (int i = 0; i < attachments; i++) {
                        HttpPostedFileBase file = Request.Files[i];
                        if (file.ContentLength > 0) {
                            var attachement = new EmailAttachment();
                            attachement.ContentLength = file.ContentLength;
                            attachement.ContentType = file.ContentType;
                            attachement.Filename = file.FileName;
                            attachement.CreateBy = 1;
                            attachement.CreateDate = DateTime.Now.ToUniversalTime();
                            logText.AppendLine("File: [FileName]: " + file.FileName);
                            logText.AppendLine("File: [ContentType]: " + file.ContentType);
                            logText.AppendLine("File: [FileSize]: " + file.ContentLength);
                            byte[] fileImage = new byte[attachement.ContentLength];
                            file.InputStream.Read(fileImage, 0, attachement.ContentLength);
                            attachement.FileContent = fileImage;
                            emailAttachments.Add(attachement);
                        }
                    }
                }
                List<MailAddress> toEmailAddress = new List<MailAddress>();
                MailAddress dropboxEmail = null;
                //Parsing Headers
                Regex toline = new Regex(@"(?im-:^To\s*:\s*(?<to>.*)$)");
                Regex ccline = new Regex(@"(?im-:^Cc\s*:\s*(?<to>.*)$)");
                MailAddress senderEmail = new MailAddress(from);
                if (!string.IsNullOrEmpty(to))
                    toEmailAddress.Add(new MailAddress(to));
                if (!string.IsNullOrEmpty(cc))
                    toEmailAddress.Add(new MailAddress(cc));
                //Envelope Json
                if (!string.IsNullOrEmpty(envelope)) {
                    envelopeObject = JsonConvert.DeserializeObject<Envelope>(envelope);
                    if (envelopeObject != null) {
                        if (envelopeObject.To != null && envelopeObject.To.Length > 0)
                            foreach (var envelopeTo in envelopeObject.To) {
                                MailAddress mailTmp = new MailAddress(envelopeTo.Trim().ToLower());
                                if (mailTmp.User.Trim().StartsWith("dropbox", StringComparison.InvariantCultureIgnoreCase))
                                    dropboxEmail = mailTmp;
                                else
                                    toEmailAddress.Add(mailTmp);
                            }
                    }
                }
                foreach (var email in ParseMIMEEmailAddresses(toline.Match(headers).Groups["to"].Value)) {
                    MailAddress mailTmp = new MailAddress(email.Trim().ToLower());
                    if (mailTmp.User.Trim().StartsWith("dropbox", StringComparison.InvariantCultureIgnoreCase))
                        dropboxEmail = mailTmp;
                    else
                        toEmailAddress.Add(mailTmp);
                }
                foreach (var email in ParseMIMEEmailAddresses(ccline.Match(headers).Groups["to"].Value)) {
                    MailAddress mailTmp = new MailAddress(email.Trim().ToLower());
                    if (mailTmp.User.Trim().StartsWith("dropbox", StringComparison.InvariantCultureIgnoreCase))
                        dropboxEmail = mailTmp;
                    else
                        toEmailAddress.Add(mailTmp);
                }
                foreach (var message in toEmailAddress)
                    logText.AppendLine("HEADER PARSE [To]: " + message.Address);
                if (dropboxEmail != null)
                    logText.AppendLine("Dropbox Email: " + dropboxEmail.Address);
                var dropLog = new DropboxLog {
                    CreateDate = DateTime.Now.ToUniversalTime(),
                    Log = logText.ToString()
                };
                _dropboxLogRepository.SaveOrUpdate(dropLog);
                _dropboxLogRepository.DbContext.CommitChanges();
                if (dropboxEmail == null)
                    return new HttpStatusCodeResult(500);
                if (toEmailAddress.Count == 0)
                    return new HttpStatusCodeResult(500);
                //Validate the the email came from a valid user/dropbox key.
                //TODO Also validate alias here
                var dropBoxKey = dropboxEmail.User.Split('+')[1];
                if (string.IsNullOrEmpty(dropBoxKey))
                    return new HttpStatusCodeResult(500);
                var user = _userService.GetUserByEmailDropBoxId(senderEmail.Address, dropBoxKey);
                if (user == null)
                    return new HttpStatusCodeResult(500);
                //Create email object
                var emailToAdd = new Email {
                    CreateBy = user.Id,
                    CreateDate = DateTime.Now.ToUniversalTime(),
                    BodyText = text,
                    BodyHtml = html,
                    Subject = subject,
                    Sender = user,
                    EmailDate = DateTime.Now.ToUniversalTime(),
                    Client = user.Client
                };
                foreach (var file in emailAttachments) {
                    file.CreateBy = user.Id;
                    emailToAdd.AddAttachment(file);
                }
                //Get all leads by email address list
                List<string> toEmails = toEmailAddress.Select(s => s.Address).ToList();
                foreach (Lead lead in _leadService.GetLeadsByEmails(user.Client.Id, user.Id, toEmails))
                    lead.AddEmail(emailToAdd);
                foreach (Contact contact in _contactService.GetContactsByEmails(user.Client.Id, user.Id, toEmails))
                    contact.AddEmail(emailToAdd);
                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex) {
                var dropLog = new DropboxLog {
                    CreateDate = DateTime.Now.ToUniversalTime(),
                    Log = ex.Message
                };
                _dropboxLogRepository.SaveOrUpdate(dropLog);
                _dropboxLogRepository.DbContext.CommitChanges();
                throw;
            }
        }
        private static IEnumerable<string> ParseMIMEEmailAddresses(string lineToParse) {
            List<string> emails = new List<string>();
            int from = 0;
            int position = 0;
            string emailText;
            while (from < lineToParse.Length) {
                int found = (found = lineToParse.IndexOf(',', from)) > 0 ? found : lineToParse.Length;
                from = found + 1;
                emailText = lineToParse.Substring(position, found - position);
                try {
                    MailAddress addy = new MailAddress(emailText.Trim());
                    emails.Add(addy.Address);
                    position = found + 1;
                }
                catch (FormatException) {
                    //Log parsing error to database for future consideration.
                }
            }
            return emails;
        }
