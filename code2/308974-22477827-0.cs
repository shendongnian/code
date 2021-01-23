        /// <summary>
        /// Sends an email from the specified account merging the signature with the text array
        /// </summary>
        /// <param name="to">email to address</param>
        /// <param name="subject">subect line</param>
        /// <param name="body">email details</param>
        /// <returns>false if account does not exist or there is another exception</returns>
        public static Boolean SendEmailFromAccount(string from, string to, string subject, List<string> text, string SignatureName)
        {
            // Retrieve the account that has the specific SMTP address. 
            Outlook.Application application = new Outlook.Application();
            Outlook.Account account = GetAccountForEmailAddress(application, from);
            // check account
            if (account == null)
            {
                return false;
            }
            // Create a new MailItem and set the To, Subject, and Body properties. 
            Outlook.MailItem newMail = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
            // Use this account to send the e-mail. 
            newMail.SendUsingAccount = account;            
            newMail.To = to;
            newMail.Subject = subject;
            string Signature = ReadSignature(SignatureName);
            newMail.HTMLBody = CreateHTMLBody(Signature, text); 
            ((Outlook._MailItem)newMail).Send();
            return true;
        }
        private static Outlook.Account GetAccountForEmailAddress(Outlook.Application application, string smtpAddress)
        {
            // Loop over the Accounts collection of the current Outlook session. 
            Outlook.Accounts accounts = application.Session.Accounts;
            foreach (Outlook.Account account in accounts)
            {
                // When the e-mail address matches, return the account. 
                if (account.SmtpAddress == smtpAddress)
                {
                    return account;
                }
            }
            throw new System.Exception(string.Format("No Account with SmtpAddress: {0} exists!", smtpAddress));
        }
        /// <summary>
        /// Return an email signature based on the template name i.e. signature.htm
        /// </summary>
        /// <param name="SignatureName">Name of the file to return without the path</param>
        /// <returns>an HTML formatted email signature or a blank string</returns>
        public static string ReadSignature(string SignatureName)
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
            if
            (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");
                foreach (FileInfo fi in fiSignature)
                {
                    if (fi.Name.ToUpper() == SignatureName.ToUpper()) 
                    {
                        StreamReader sr = new StreamReader(fi.FullName, Encoding.Default);
                        signature = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(signature))
                        {
                            // this merges the information in the signature files together as one string 
                            // with the correct relative paths
                            string fileName = fi.Name.Replace(fi.Extension, string.Empty);
                            signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                        }
                        return signature; 
                    }
                }
            }
            return signature;
        }
        /// <summary>
        /// Merges an email signature with an array of plain text
        /// </summary>
        /// <param name="signature">string with the HTML email signature</param>
        /// <param name="text">array of text items as the content of the email</param>
        /// <returns>an HTML email body</returns>
        public static string CreateHTMLBody(string signature, List<string> text)
        {
            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                HtmlAgilityPack.HtmlNode node;
                HtmlAgilityPack.HtmlNode txtnode;
                // if the signature is empty then create a new string with the text
                if (signature.Length == 0)
                {
                    node = HtmlAgilityPack.HtmlNode.CreateNode("<html><head></head><body></body></html>");
                    doc.DocumentNode.AppendChild(node);
                    // select the <body>
                    node = doc.DocumentNode.SelectSingleNode("/html/body");
                    // loop through the text lines and insert them
                    for (int i = 0; i < text.Count; i++)
                    {
                        node.AppendChild(HtmlAgilityPack.HtmlNode.CreateNode("<p>" + text[i] + "</p>"));
                    }
                    // return the full document
                    signature = doc.DocumentNode.OuterHtml;
                    return signature;
                }
                // load the signature string as HTML doc
                doc.LoadHtml(signature);
                // get the root node and insert the text paragraphs before the signature in the document
                node = doc.DocumentNode;
                node = node.FirstChild;
                foreach (HtmlAgilityPack.HtmlNode cn in node.ChildNodes)
                {
                    if (cn.Name == "body")
                    {
                        foreach (HtmlAgilityPack.HtmlNode cn2 in cn.ChildNodes)
                        {
                            if (cn2.Name == "div")
                            {
                                // loop through the text lines backwards as we are inserting them at the top
                                for (int i = text.Count -1; i >= 0; i--)
                                {
                                    if (text[i].Length == 0)
                                    {
                                        txtnode = HtmlAgilityPack.HtmlNode.CreateNode("<p class=\"MsoNormal\"><o:p>&nbsp;</o:p></p>");
                                    }
                                    else
                                    {
                                        txtnode = HtmlAgilityPack.HtmlNode.CreateNode("<p class=\"MsoNormal\">" + text[i] + "<o:p></o:p></p>");
                                    }
                                    cn2.InsertBefore(txtnode, cn2.FirstChild);                                   
                                }
                                // return the full document
                                signature = doc.DocumentNode.OuterHtml;
                            }
                        }
                    }
                }
                return signature;
            }
            catch (Exception)
            {
                return "";
            }
        }
