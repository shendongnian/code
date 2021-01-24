    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
    Text lineTxt = new Text("A VERY LONG TEXT SHOULD BE SCALED");
    iText.Kernel.Geom.Rectangle lineTxtRect = new iText.Kernel.Geom.Rectangle(100, 200, 100, 100);
    Div lineDiv = new Div();
    lineDiv.SetVerticalAlignment(VerticalAlignment.MIDDLE);
    lineDiv.SetBorder(new DashedBorder(1));
    Paragraph linePara = new Paragraph().Add(lineTxt)
        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBorder(new DottedBorder(1))
        .SetMultipliedLeading(0.7f);
    lineDiv.Add(linePara);
    float fontSizeL = 1; // 1 is the font size that is definitely small enough to draw all the text 
    float fontSizeR = 20; // 20 is the maximum value of the font size you want to use
    Canvas canvas = new Canvas(new PdfCanvas(pdfDocument.AddNewPage()), pdfDocument, lineTxtRect);
    // Binary search on the font size
    while (Math.Abs(fontSizeL - fontSizeR) > 1e-1) {
        float curFontSize = (fontSizeL + fontSizeR) / 2;
        lineDiv.SetFontSize(curFontSize);
        // It is important to set parent for the current element renderer to a root renderer
        IRenderer renderer = lineDiv.CreateRendererSubTree().SetParent(canvas.GetRenderer());
        LayoutContext context = new LayoutContext(new LayoutArea(1, lineTxtRect));
        if (renderer.Layout(context).GetStatus() == LayoutResult.FULL) {
            // we can fit all the text with curFontSize
            fontSizeL = curFontSize;
        } else {
            fontSizeR = curFontSize;
        }
    }
    // Use the biggest font size that is still small enough to fit all the text
    lineDiv.SetFontSize(fontSizeL);
    canvas.Add(lineDiv);
    
    pdfDocument.Close();
