          var AllDocs = //List of image names
          string path = HttpContext.Server.MapPath("~/Content/TempImages/");
          List<FileInfo> filelist = new List<FileInfo>();
          foreach (var item in AllDocs)
          {
             filelist.Add(new FileInfo(path + item.ImageName));
          }
 
