                 }catch(Exception ex)
                 {
                    LogLastError(ex);
                    Console.WriteLine(ex.Message);
                    TempData["Error"] = "Cannot contain null values in the Excel sheet";
    
             }
            public void LogLastError(Exception ex)
            {
                System.Web.HttpContext con = System.Web.HttpContext.Current;
    
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Page          : " + con.Request.Url.ToString());
                sb.AppendLine("Error Message : " + ex.Message);
                if (ex.InnerException != null)
                {
                    sb.AppendLine("Inner Message : " + ex.InnerException.ToString());
                }
    
                string fileName = System.IO.Path.Combine(Server.MapPath("~/Errors"), 
                DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt");
                System.IO.File.WriteAllText(fileName, sb.ToString());
            }
