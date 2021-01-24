            i_iMAPI = i_rdoS.GetRDOObjectFromOutlookObject(i_rdoMessage, true);
            i_MAPI = i_rdoS.GetRDOObjectFromOutlookObject(i_rdoMessage);
            
            //if signed message remove key file and set MessageClass to standard Message
            if (i_iMAPI.MessageClass == "IPM.Note.SMIME.MultipartSigned")
            {
                i_iMAPI.MessageClass = "IPM.Note";
                //remove the key file and make sure it is really key file
                foreach (RDOAttachment att in i_iMAPI.Attachments)
                {
                    if (att.DisplayName == "Untitled Attachment")
                    {
                        att.Delete();
                    }
                }
                //create specific Folder for each sender
                i_FilePath = Folders.StorageFolder + i_MAPI.SenderName;
                i_Folder.CreateFolder(i_FilePath);
            
                //remapp the attachements from MAPI to iMAPI Message
                foreach (RDOAttachment rdoAtt in i_MAPI.Attachments)
                {
                    rdoAtt.SaveAsFile(i_FilePath + @"\" + rdoAtt.FileName);                    
                    i_iMAPI.Attachments.Add(i_FilePath + @"\" + rdoAtt.FileName);                    
                    i_iMAPI.Attachments[i_iMAPI.Attachments.Count].Hidden = rdoAtt.Hidden;                                        
                }
                //save changes
                i_iMAPI.Save();
            }
