    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Default7 : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string baseImageLocation = Server.MapPath("Images\\");
            HttpFileCollection uploads = HttpContext.Current.Request.Files;
    
            HttpPostedFile file = uploads["uploadPicture"];
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            string fileName = Path.GetFileName(file.FileName);
            if (fileName != "")
            {
                if (fileExt == ".jpg" || fileExt == ".gif")
                    file.SaveAs(baseImageLocation + fileName);
    
            }
        }
    }
