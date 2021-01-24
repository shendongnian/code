    DirectoryInfo d = new DirectoryInfo(@"D:\"+Folder_name+"\"+SubFolder_name");
    FileInfo[] Files = d.GetFiles("*.jpg"); //Getting Text files
    string str = "";
    foreach(FileInfo file in Files )
    {
    var path = Path.Combine("~\\" + Folder_name+ "\\" + SubFolder_name + "\\"file.Name;
      ImageBase64(path);
    }
    
     private string ImageBase64(string Path )
            {
                path = System.Web.Hosting.HostingEnvironment.MapPath(path);
                var ext = System.IO.Path.GetExtension(path);
                var contents = System.IO.File.ReadAllBytes(path);
                MemoryStream ms = new MemoryStream(contents);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
    
            }
