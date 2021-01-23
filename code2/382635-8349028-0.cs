    public class Previewer
    {
         public static PreviewDocumentType PreviewDocument(ReportingObject reportingObj) {
           reportingObj.Render();
           return reportingObj.PreviewDocument;
         }
    }
