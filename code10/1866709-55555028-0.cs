     public ActionResult Download()
            {
                string url = (string)TempData["url"];
    
                url = "http://www.iuh.edu.vn/Tuyensinh/QC/TomTatQuyCheThiTHPT2018.pdf";
    
                using (var client = new WebClient())
                {
                    // read data
                    byte[] thePdf = client.DownloadData(url);
    
                    return File(thePdf, "application/pdf");
    
                }
                
                //byte[] thePdf = System.IO.File.ReadAllBytes(url);
    
                //return File(thePdf, "application/pdf");
            }
