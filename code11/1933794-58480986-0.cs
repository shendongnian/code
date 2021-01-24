private void StickerInMM()
{
        var Sticker = new Rectangle(241, 142);
        var writer = new PdfWriter("Test " + DateTime.Now.ToString("dd-MM-yyy") + ".pdf");
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf, new PageSize(Sticker));
        document.SetMargins(0, 0, 0, 0);
        ImageData data = ImageDataFactory.Create("c:/Users/Public/Cyaan.jpg");
        Image img = new Image(data);
        img.SetHeight(15);
        ImageData data2 = ImageDataFactory.Create("c:/Users/Public/Tekst.jpg");
        Image img2 = new Image(data2);
        img2.ScaleToFit(100, 100);
        var EANFONT = PdfFontFactory.CreateFont("c:/Users/Public/ean13.ttf", PdfEncodings.IDENTITY_H, true);
        var cellean = new Paragraph(richTextBox2.Text)
            .SetFontSize(38)
            .SetFont(EANFONT);
        var table = new Table(new float[] { 1 });
        table.SetWidth(UnitValue.CreatePercentValue(100));
        table.AddCell("Laser toner cartridge");
        document.Add(table);
        var table2 = new Table(new float[] { 3, 1 });
        table2.SetWidth(UnitValue.CreatePercentValue(100));
        table2.AddCell("Test");
        table2.AddCell(img);
        document.Add(table2);
        var table3 = new Table(new float[] { 1 });
        table3.SetWidth(UnitValue.CreatePercentValue(100));
        table3.AddCell("Test");
        document.Add(table3);
        var table4 = new Table(new float[] { 2, 2 });
        table4.SetWidth(UnitValue.CreatePercentValue(100));
        table4.AddCell(img2);          
        table4.AddCell(cellean);
        document.Add(table4);
        document.Close();
    }
Fixed it with the code above :D !
