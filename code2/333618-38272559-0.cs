    Response.Clear();
                Response.Buffer = true;
                Response.BufferOutput = true;
                Response.ContentType = "application/x-download";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.CacheControl = "public";
                // writes buffer to OutputStream
                Response.OutputStream.Write(buffer, 0, buffer.Length);
                Response.End();
