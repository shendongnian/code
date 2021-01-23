            private MailMessage MM_ShallowClone(MailMessage original)
            {
                string to = original.To.ToString();
                string from = original.From.ToString();
                string subject = original.Subject;
                string body = original.Body;
                string cc = (original.CC == null) ? null : original.CC.ToString();
                string bcc = (original.Bcc == null) ? null : original.Bcc.ToString();
                MailMessage clone = new MailMessage(from, to, subject, body);
                if(cc != null) clone.CC.Add(cc);
                if(bcc !=  null) clone.Bcc.Add(bcc);
                foreach (AlternateView a in original.AlternateViews)
                {
                    clone.AlternateViews.Add(a);
                }
                foreach(Attachment a in original.Attachments)
                {
                    clone.Attachments.Add(a);
                }
                clone.BodyEncoding = original.BodyEncoding;
                clone.DeliveryNotificationOptions = original.DeliveryNotificationOptions;
                foreach (System.Collections.Specialized.NameValueCollection h in original.Headers)
                {
                    clone.Headers.Add(h);
                }
                clone.HeadersEncoding = original.HeadersEncoding;
                clone.IsBodyHtml = original.IsBodyHtml;
                clone.Priority = original.Priority;
                clone.ReplyTo = original.ReplyTo;
                foreach (MailAddress a in original.ReplyToList)
                {
                    clone.ReplyToList.Add(a);
                }
                clone.Sender = original.Sender;
                clone.SubjectEncoding = original.SubjectEncoding;
                return clone;             
        }
