                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=file.pdf");
                Response.BufferOutput = true;
                Response.AddHeader("Content-Length", docBytes.Length.ToString());
                Response.BinaryWrite(docBytes);
                Response.End();
