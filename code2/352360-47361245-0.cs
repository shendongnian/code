     PdfPTable resimtable = new PdfPTable(2); // two colmns create tabble
     resimtable.WidthPercentage = 100f;//table %100 width
     iTextSharp.text.Image imgsag = iTextSharp.text.Image.GetInstance(Application.StartupPath+"/sagkulak.jpg");
    iTextSharp.text.Image imgsol = iTextSharp.text.Image.GetInstance(Application.StartupPath + "/sagkulak.jpg");
    resimtable.AddCell(imgsag);//Table One colmns added first image
    resimtable.AddCell(imgsol);//Table two colmns added second image
