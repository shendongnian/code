    files = Request.Files.Count;
    if(files > 0) {
       // Files are sent!
       for (int i = 0; i < files; i++) {
          var file = Request.Files[i];
          // Got the image...
          string fileName = Path.GetFileName(file.FileName);
          // Save the file...
          file.SaveAs(Server.MapPath("~/" + fileName));
       }
    }
