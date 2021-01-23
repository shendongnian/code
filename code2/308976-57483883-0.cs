        public static void SendMail(string subject, string message, List<string> attachments, string recipients)
        {
            try
            {
                Outlook.Application application = new Outlook.Application();
                
                Outlook.MailItem mailItem = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
                Word.Document  worDocument = mailItem.GetInspector.WordEditor as Word.Document;
                Word.Range wordRange = worDocument.Range(0, 0);
                wordRange.Text = message;
                
                foreach (string attachment in attachments ?? Enumerable.Empty<string>())
                {
                    string displayName = GetFileName(attachment);
                    int position = (int)mailItem.Body.Length + 1;
                    int attachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment attachmentItem = mailItem.Attachments.Add
                        (attachment, attachType, position, displayName);
                }
                
                mailItem.Subject = subject;
                Outlook.Recipients recipientsItems = (Outlook.Recipients)mailItem.Recipients;
                Outlook.Recipient recipientsItem = (Outlook.Recipient)recipientsItems.Add(recipients);
                recipientsItem.Resolve();
                mailItem.Display();
                recipientsItem = null;
                recipientsItems = null;
                mailItem = null;
                application = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private static string GetFileName(string fullpath)
        {
            string fileName = Path.GetFileNameWithoutExtension(fullpath);
            return fileName;
        }
