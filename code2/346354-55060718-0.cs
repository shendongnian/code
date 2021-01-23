      PdfReader reader = new PdfReader("D:/Sample2.pdf");
            PdfDocument pdfDoc = new PdfDocument(reader);
            Rectangle rect = new Rectangle(208, 508, 235, 519);
            TextRegionEventFilter regionFilter = new TextRegionEventFilter(rect.SetBbox(208, 508, 235, 519));
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            FilteredEventListener listener = new FilteredEventListener();
            LocationTextExtractionStrategy extractionStrategy = listener.AttachEventListener(new LocationTextExtractionStrategy(), regionFilter);
            new PdfCanvasProcessor(listener).ProcessPageContent(pdfDoc.GetPage(1));
            String text = extractionStrategy.GetResultantText();
