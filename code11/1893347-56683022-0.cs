    FileStream writer = File.Create(filePath);
    writer.AppendText("Exception Detail Start-------------------------------------------");
    writerAppendText("Stack Trace :" + ex.StackTrace );
    writer.AppendText("Error :" + ex.Message );
    writer.AppendText("Exception Detail End-------------------------------------------");
