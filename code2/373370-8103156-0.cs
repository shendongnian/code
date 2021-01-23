              context.Response.ContentType = "image/pjpeg"; 
              context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + photoName  + "\"");
              OutputCacheResponse(context, File.GetLastWriteTime(photoPath));
                
               context.Response.Flush();
                                            
              
               using (FileStream diskCacheStream = new FileStream(cachePath, FileMode.CreateNew))
               {
                   memoryStream.WriteTo(diskCacheStream);
               }
                memoryStream.WriteTo(context.Response.OutputStream);
