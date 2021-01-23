                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.AppendHeader("content-disposition",string.Format("attachment; filename={0}", "Path.GetFileName(strVirtualFilePath);"));
                    HttpContext.Current.Response.WriteFile(_strVirtualFilePath);
                    HttpContext.Current.Response.End();
                    HttpContext.Current.Response.Flush();
