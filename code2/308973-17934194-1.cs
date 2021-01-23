        string billede1 = string.Empty;    // holding image1
        string billede2 = string.Empty;    // holding image2
                            string signature = ReadSignature();
                            if (signature.Contains("img"))
                            {
                                int position = signature.LastIndexOf("img");
                                int position1 = signature.IndexOf("src", position);
                                position1 = position1 + 5;
                                position = signature.IndexOf("\"", position1);
                                //CONTENT-ID
                                const string SchemaPR_ATTACH_CONTENT_ID = @"http://schemas.microsoft.com/mapi/proptag/0x3712001E";
                                string contentID = Guid.NewGuid().ToString();
                                //Attach image
                                mailItem.Attachments.Add(@billede1, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, mailItem.Body.Length, Type.Missing);
                                mailItem.Attachments[mailItem.Attachments.Count].PropertyAccessor.SetProperty(SchemaPR_ATTACH_CONTENT_ID, contentID);
                                //Create and add banner
                                string banner = string.Format(@"cid:{0}", contentID);
                                signature = signature.Remove(position1, position - position1);
                                signature = signature.Insert(position1, banner);
                                position = signature.LastIndexOf("imagedata");
                                position1 = signature.IndexOf("src", position);
                                position1 = position1 + 5;
                                position = signature.IndexOf("\"", position1);
                                //CONTENT-ID
                               // const string SchemaPR_ATTACH_CONTENT_ID = @"http://schemas.microsoft.com/mapi/proptag/0x3712001E";
                                contentID = Guid.NewGuid().ToString();
                                //Attach image
                                mailItem.Attachments.Add(@billede2, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, mailItem.Body.Length, Type.Missing);
                                mailItem.Attachments[mailItem.Attachments.Count].PropertyAccessor.SetProperty(SchemaPR_ATTACH_CONTENT_ID, contentID);
                                //Create and add banner
                                banner = string.Format(@"cid:{0}", contentID);
                                signature = signature.Remove(position1, position - position1);
                                signature = signature.Insert(position1, banner);
                            }
                            mailItem.HTMLBody = mailItem.Body + signature;
