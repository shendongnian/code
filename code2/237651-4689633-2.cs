         private void PushToBrowser(string FilePath, byte[] Data)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = @"application/csv";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
            HttpContext.Current.Response.OutputStream.Write(Data, 0, Data.Length);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
            File.Delete(FilePath);
        }
