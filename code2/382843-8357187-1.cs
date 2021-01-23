    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.html.simpleparser;
    
    public partial class panelTest : Page {
      protected void process(object sender, CommandEventArgs e) {
        string attachment = "attachment; filename=test.pdf";
        Response.AddHeader("content-disposition", attachment);    
        Response.ContentType = "application/pdf";
        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
        htmlWriter.AddStyleAttribute("font-size", "10pt");
        htmlWriter.AddStyleAttribute("color", "Black");      
        testPanel.RenderControl(htmlWriter);
        using (Document document = new Document()) {
          PdfWriter.GetInstance(document, Response.OutputStream);
          document.Open();
          StringReader stringReader = new StringReader(stringWriter.ToString());
          HTMLWorker htmlworker = new HTMLWorker(document);
          htmlworker.Parse(stringReader);    
        }
        Response.End();
      }
    }
