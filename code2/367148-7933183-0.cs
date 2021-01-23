    <%@ WebHandler Language="C#" %>
    
    using System;
    using System.Web;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Collections.Generic;
    using System.Linq;
    
    public class ImageHandler : IHttpHandler {
       
        public void ProcessRequest (HttpContext context)
        {
            HttpRequest req = context.Request;          
            // string categoryID = "1";          
            string categoryID = req.QueryString["CategoryID"].ToString();          
            // Get information about the specified category          
            NorthwindDataContext db = new NorthwindDataContext();          
            var category = from c in db.Categories                         
                           where Convert.ToInt32(c.CategoryID) == Convert.ToInt32(categoryID)
                           select c.Picture;          
            int len = category.First().Length;          
            // Output the binary data          
            // But first we need to strip out the OLE header          
            int OleHeaderLength = 78;          
            int strippedImageLength = len - OleHeaderLength;          
            byte[] imagdata = new byte[strippedImageLength];          
            Array.Copy(category.First().ToArray(), OleHeaderLength, imagdata, 0, strippedImageLength);          
            if ((imagdata) != null)          
            {              
                MemoryStream m = new MemoryStream(imagdata);              
                System.Drawing.Image image = System.Drawing.Image.FromStream(m);              
                image.Save(context.Response.OutputStream, ImageFormat.Jpeg);          
            }
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
            
