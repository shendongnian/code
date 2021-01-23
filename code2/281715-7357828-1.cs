    private void btnGetAIThumb_Click(object sender, EventArgs e)
    {
        Illustrator.Application app = new Illustrator.Application();
        Illustrator.Document doc = app.Open(@"F:/AI_Prog/2009Calendar.ai", Illustrator.AiDocumentColorSpace.aiDocumentRGBColor, null);
        doc.Export(@"F:/AI_Prog/2009Calendar.png",Illustrator.AiExportType.aiPNG24, null);  
        doc.Close(Illustrator.AiSaveOptions.aiDoNotSaveChanges); 
        doc = null; //
    }
