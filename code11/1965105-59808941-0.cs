     public partial class Page: System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
                Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                wordDocument = appWord.Documents.Open(@"C:\\Users\\IT-TEAM\\text0\\y" + textBox1.Text + ".docx");
                wordDocument.ExportAsFixedFormat(@"C:\\Users\\IT-TEAM\\y" + textBox1.Text + ".pdf", WdExportFormat.wdExportFormatPDF);
            }
        
            public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
        }
        }
