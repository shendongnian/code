    FileStream oFileStreamDec = new FileStream(@"C:\Decrypted_AMS.cfg", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
    oFileStreamDec.Write(DecryptedXML, 0, DecryptedXML.Length);
    // Close the File first
    oFileStreamDec.Close();
    //Create file security and apply rules to it
    FileSecurity oFileSecurity = new FileSecurity();
    oFileSecurity.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule("Everyone", System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
    System.IO.File.SetAccessControl(@"C:\Decrypted_AMS.cfg", oFileSecurity);
