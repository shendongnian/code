    private void ExportToPDFUsingDevExpress(string sourceDoc, string destPDF)
        {
            DevExpress.XtraPrinting.PrintingSystem printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraRichEdit.RichEditControl richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            richEditControl1.LoadDocument(sourceDoc);
            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(printingSystem1);
            link.Component = richEditControl1;
            link.CreateDocument();
            link.PrintingSystem.ExportToPdf(destPDF);
        }
