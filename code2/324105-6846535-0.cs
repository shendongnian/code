       public class ContentController : Controller
        {
            public ActionResult LoadContent(string dir, string file)
            {
                string fileName = Server.MapPath(Url.Content("~/Content/" + dir)) 
                filename += "\\" + file;            
    
                // stream file if exists    
                FileInfo info = new FileInfo(fileName);
                if (info.Exists)
                    return File(info.OpenRead(), MimeType(fileName));
    
                
                // else return null - file not found
                return null;            
            }
    
    
            private string MimeType(string filename)
            {
                string mime = "application/octetstream";
                var extension = Path.GetExtension(filename);
                if (extension != null)
                {
                    string ext = extension.ToLower();
                    RegistryKey rk = Registry.ClassesRoot.OpenSubKey(ext);
    
                    if (rk != null && rk.GetValue("Content Type") != null)
                        mime = rk.GetValue("Content Type").ToString();
                }
    
                return mime;
            }
        }
