    byte [] buffer = new byte[1<<16] // 64kb
    int bytesRead = 0;
    using(var file = File.Open(path))
    {
       while((bytesRead = file.Read(buffer, 0, buffer.Length)) != 0)
       {
            Response.OutputStream.Write(buffer, 0, bytesRead);
             // can sleep here or whatever
       }
    }
    Response.Flush();
    Response.Close();
    Response.End();
