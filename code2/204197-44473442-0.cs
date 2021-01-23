       Create HtmltoPdf()
       {
       if (System.IO.File.Exists("HTMLFile.html"))
        {
            System.IO.File.Delete("HTMLFile.html");
        }
        System.IO.File.WriteAllText("HTMLFile.html", html);
        var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
        if (System.IO.File.Exists("export.pdf"))
        {
            System.IO.File.Delete("export.pdf");
        }
        htmlToPdf.GeneratePdfFromFile("HTMLFile.html", null, "export.pdf");
     }
