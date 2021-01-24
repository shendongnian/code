`
            PrinterSettings settings = new PrinterSettings();
            string PrinterName = settings.PrinterName;
            //set paper size
            PaperSize oPS = new PaperSize
            {
                RawKind = (int)PaperKind.A4
            };
            //choose the tray here
            PaperSource oPSource = new PaperSource
            {
                RawKind = (int)PaperSourceKind.Upper
            };
            PrintDocument printDoc = new PrintDocument
            {
                PrinterSettings = settings,
            };
            //set printer name here it's the default printer
            printDoc.PrinterSettings.PrinterName = PrinterName;
            printDoc.DefaultPageSettings.PaperSize = oPS;
            printDoc.DefaultPageSettings.PaperSource = oPSource;
            printDoc.PrintPage += new PrintPageEventHandler((sender, args) =>
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(imageFilePath);
                int printHeight = (int)printDoc.DefaultPageSettings.PrintableArea.Height;
                int printWidth = (int)printDoc.DefaultPageSettings.PrintableArea.Width;
                int leftMargin = 0;
                int rightMargin = 0;
                args.Graphics.DrawImage(img, new System.Drawing.Rectangle(leftMargin, rightMargin, printWidth, printHeight));
            });
            printDoc.Print();
            printDoc.Dispose();
`
