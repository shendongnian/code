            var ctrl = new StandardPrintController();
            using (var document = PdfDocument.Load(filename))
            {
                using (PrintDocument doc = document.CreatePrintDocument())
                {
                    doc.PrintController = ctrl;
                    doc.PrinterSettings.PrinterName = "CutePDF Writer";
                    doc.PrinterSettings.PrintFileName = fileName;
                    doc.PrintPage += (s, e) =>
                    {
                        pageNo++;
                        if (pageNo < frameCount)
                        {
                            e.HasMorePages = true;
                        }
                        else
                        {
                            e.HasMorePages = false;
                        }
                    };
                    doc.Print();
                }
            }
        }
    }
