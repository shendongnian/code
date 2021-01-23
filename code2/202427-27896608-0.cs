     if (mailItem.Attachments.Count > 0)
            {
                // get attachments
                foreach (Attachment attachment in mailItem.Attachments)
                {
                    var flags = attachment.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x37140003");
                    //To ignore embedded attachments -
                    if (flags != 4)
                    {
                        // As per present understanding - If rtF mail attachment comes here - and the embeded image is treated as attachment then Type value is 6 and ignore it
                        if ((int)attachment.Type != 6)
                        {
                            MailAttachment mailAttachment = new MailAttachment { Name = attachment.FileName };
                            mail.Attachments.Add(mailAttachment);
                        }
                    }
                }
            }
