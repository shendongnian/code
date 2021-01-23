    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                    {
                        var pic = System.Web.HttpContext.Current.Request.Files["filekey"];
                        HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                        var fileName = Path.GetFileName(filebase.FileName);
    
    
                        string fileExtension = System.IO.Path.GetExtension(fileName);
    
                        if (fileExtension == ".xls" || fileExtension == ".xlsx")
                        {
                            string FileName = Guid.NewGuid().GetHashCode().ToString("x");
                            string dirLocation = Server.MapPath("~/Content/PacketExcel/");
                            if (!Directory.Exists(dirLocation))
                            {
                                Directory.CreateDirectory(dirLocation);
                            }
                            string fileLocation = Server.MapPath("~/Content/PacketExcel/") + FileName + fileExtension;
                            filebase.SaveAs(fileLocation);
    }
    }
