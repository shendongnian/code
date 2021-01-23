    <%@ WebHandler Language="C#" Class="Handler" %>
    
        using System;
        using System.Web;
        
        public class Handler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
               
                foreach(string f in context.Request.Files.AllKeys) 
                {
        	       HttpPostedFile file = context.Request.Files[f];
        	       file.SaveAs("c:\\inetpub\\test\\UploadedFiles\\" + file.FileName);
                 // alternatively:
                 file.SaveAs(Path.Combine(Server.MapPath(@"\StorageFolder\",file.FileName);
                 //thanks @SLaks.
        	    }
             }
         } 
