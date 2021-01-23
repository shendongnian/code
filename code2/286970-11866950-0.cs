            Dim Lic As New Aspose.Words.License
            Lic.SetLicense(Application.StartupPath & "\Aspose.Words.lic")
    
            Dim doc As New Aspose.Words.Document()
            Dim docBuilder As New Aspose.Words.DocumentBuilder(doc)
            docBuilder.InsertParagraph()
            docBuilder.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary)
            docBuilder.Write("Hello World")
            docBuilder.MoveToSection(0)
            Dim f As Aspose.Words.Font = docBuilder.Font
            f.HighlightColor = Color.Yellow
            f.Size = 16
            f.Name = "Courier New"
            docBuilder.Write("hola")
    
            doc.Save("C:\HeaderTest.doc")
