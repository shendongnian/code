    try
            {
                string FileName = Request.QueryString["file"];
                Response.AppendHeader("Content-Type", "application/force-download;");    
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
                Response.WriteFile(@Server.MapPath("download/") + "\\" + FileName);
                Response.End();
            }
            catch (Exception)
            {
                //Handle Error
            }
