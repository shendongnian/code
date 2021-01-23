    <%@ WebHandler Language="C#" Class="copyFillTemplate" %>
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public class copyFillTemplate : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        HttpServerUtility Server = context.Server;
        HttpResponse Response = context.Response;
        Response.ContentType = "application/pdf";
    // template used to test __this__ example;
    // replace with __your__ PDF template
        string pdfTemplatePath = Server.MapPath(
          "~/app_data/template.pdf"
        );
    // this example's test data; replace with __your__ data collection   
        List<Statement> statementList = Statement.GetStatements();
        using (Document document = new Document()) {
    // PdfSmartCopy reduces PDF file size by reusing parts
    // of the PDF template, but uses more memory. you can
    // replace PdfSmartCopy with PdfCopy if memory is an issue
          using (PdfSmartCopy copy = new PdfSmartCopy(
            document, Response.OutputStream)
          ) 
          {
            document.Open();
    // used to test this example
            int counter = 0;
    // generate one page per statement        
            foreach (Statement statment in statementList) {
              ++counter;
    // replace this with your PDF form template          
              PdfReader reader = new PdfReader(pdfTemplatePath);
              using (var ms = new MemoryStream()) {
                using (PdfStamper stamper = new PdfStamper(reader, ms)) {
                  AcroFields form = stamper.AcroFields;
    // replace this with your field data for each page
                  form.SetField("title", counter.ToString());
                  stamper.FormFlattening = true;
                }
                reader = new PdfReader(ms.ToArray());
    // add one page at a time; assumes your template is only one page.
    // if your template is more than one page you will need to 
    // call GetImportedPage() for each page in your template
                copy.AddPage(copy.GetImportedPage(reader, 1));
              }
            }
          }
        }
      }
      public bool IsReusable { get { return false; } }
      
      public class Statement {
        public string FieldName, FieldValue;
        public static List<Statement> GetStatements() {
          List<Statement> s = new List<Statement>();
          for (int i = 0; i < 5; ++i) {s.Add(new Statement());}
          return s;
        }
      }
    }
