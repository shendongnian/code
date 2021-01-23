    <%@ WebHandler Language="C#" Class="iTextXfa" %>
    using System;
    using System.Web;
    using iTextSharp.text;  
    using iTextSharp.text.pdf;
    
    public class iTextXfa : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpServerUtility Server = context.Server;
        string[] testFiles = { 
          Server.MapPath("./non-XFA.pdf"), Server.MapPath("./XFA.pdf") 
        };
        foreach (string file in testFiles) {
          XfaForm xfa = new XfaForm(new PdfReader(file));
          context.Response.Write(string.Format(
            "<p>File: {0} is XFA: {1}</p>",
            file,
            xfa.XfaPresent ? "YES" : "NO"
          ));
        }
      }
      public bool IsReusable { get { return false; } }
    }
