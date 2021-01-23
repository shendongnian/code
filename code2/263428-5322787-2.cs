    <%@ WebHandler Language='C#' Class='styles' %>
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Web;
    using iTextSharp.text.html;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text;  
    using iTextSharp.text.pdf;  
    
    public class styles : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
        string Html = @"
    <h1>h1</h1>
    <p>A paragraph</p>    
    <ul> 
    <li>one</li>   
    <li>two</li>   
    <li>three</li>   
    </ul>";
        StyleSheet styles = new StyleSheet();
        styles.LoadTagStyle(HtmlTags.H1, HtmlTags.FONTSIZE, "16");
        styles.LoadTagStyle(HtmlTags.P, HtmlTags.FONTSIZE, "10");
        styles.LoadTagStyle(HtmlTags.P, HtmlTags.COLOR, "#ff0000");
        styles.LoadTagStyle(HtmlTags.UL, HtmlTags.INDENT, "10");
        styles.LoadTagStyle(HtmlTags.LI, HtmlTags.LEADING, "16");
        using (Document document = new Document()) {
          PdfWriter.GetInstance(document, Response.OutputStream);
          document.Open();
          List<IElement> objects = HTMLWorker.ParseToList(
            new StringReader(Html), styles
          );
          foreach (IElement element in objects) {
            document.Add(element);
          }
        }
     }
      public bool IsReusable {
          get { return false; }
      }
    } 
