    using System;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using PdfSharp.Pdf;
    
    //Controller for a PdfResult
    namespace Web.Utilities
    {
        public class PdfResult : ActionResult
    {
        public String Filename { get; set; }
        protected MemoryStream pdfStream = new MemoryStream();
        public PdfResult(PdfDocument doc)
        {
            Filename = String.Format("{0}.pdf", doc.Info.Title);
            doc.Save(pdfStream, false);
        }
        public PdfResult(String pdfpath)
        {
            /* optional if requried ToString save ToString file System */
            throw new NotImplementedException("PdfResult is just an example and does not serve files from the filesystem.");
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "application/pdf";
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + Filename); // specify filename
            context.HttpContext.Response.AddHeader("content-length", pdfStream.Length.ToString());
            context.HttpContext.Response.BinaryWrite(pdfStream.ToArray());
            context.HttpContext.Response.Flush();
            pdfStream.Close();
            context.HttpContext.Response.End();
        }
    
    }
