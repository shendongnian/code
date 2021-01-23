    PrintDocument document = new PrintDocument();
            PrintDialog dialog = new PrintDialog();
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            private  Font printFont;
            private string stringToPrint;
          //  private int linesPerPage=9;
            private Font printFont1;
            QRCode qrCode1;
            private string stringToPrint1;
            private string databasePath;
            int i=1;
            public Form1()
            {
                InitializeComponent();
    
                
                //document.DefaultPageSettings.PrinterSettings.PrinterName = "GODEX500";
                //  document.DefaultPageSettings.Landscape = true;
                document.DefaultPageSettings.PaperSize = new PaperSize("75 x50 mm", 300, 200);
                document.DefaultPageSettings.Margins = new Margins(1, 1, 1, 1);
                printFont = new Font("Arial", 10);
                // printFont1 = new Font("NewBarcodeFont", 12);
    
                //    document= new Font("GODEX-NewBarcodeFont", 12, FontStyle.Regular);
                // document.OriginAtMargins = true;
                //This PrintController worked fine and not showing printing this document using window
                PrintController printController = new StandardPrintController();
                document.PrintController = printController;
                document.PrintPage += new PrintPageEventHandler(document_PrintPage);
    
            }
