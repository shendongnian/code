    [HttpPost]
        public JsonResult UploadAudio()
        {
            HttpFileCollectionBase Files = Request.Files;
    
            bool fileSaved = false;
           foreach (string h in Files.AllKeys)
           {
               if (Files[h].ContentLength > 0)
               {
                   string fileName = Files[h].FileName; 
                   int fileSize =Files[h].ContentLength;
                   string serverPath = Path.Combine(Server.MapPath("..\\Your\\Favorite\\Location\\"));
                   
                   if (!Directory.Exists(serverPath))
                   {
                       Directory.CreateDirectory(serverPath);
                   }
                   try
                   {
                        //Get & Save the File
                        Request.Files.Get(h).SaveAs(serverPath + fileName);
                        fileSaved = true;
                   }
                   catch (Exception ex)
                   { 
                        
                   }
               }
           }
            return Json(new {FileSaved = fileSaved});
        }
