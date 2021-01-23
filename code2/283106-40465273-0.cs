    FileStream file = new FileStream(attachment, FileMode.Open, FileAccess.Read);
    MemoryStream ms = new MemoryStream();
    byte[] bytes = new byte[file.Length];
    file.Read(bytes, 0, (int)file.Length);
    ms.Write(bytes, 0, (int)file.Length);
    objEmail.Attachments.Add(new Attachment(ms, new FileInfo(attachment).Name));
    
    file.Close();
    ms.Close();
    System.GC.Collect();
    System.GC.WaitForPendingFinalizers();
    System.IO.File.Delete(attachment);
