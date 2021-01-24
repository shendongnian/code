     public ActionResult GetFileContent(string FileName, string LogPath)
            {
                try
                {
                    string _FilePath = Path.Combine(LogPath, FileName);
    
                    byte[] fileBytes = System.IO.File.ReadAllBytes(_FilePath);
    
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                }
                catch (Exception ex)
                {
                    return Json("Error while reading file, Please check file path", JsonRequestBehavior.AllowGet);
                }
            }
