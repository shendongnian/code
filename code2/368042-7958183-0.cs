    private static void BuildDocument(string fileName, List<string> text)
    {
      using (WordprocessingDocument wordDoc =
        WordprocessingDocument.Create(fileName,
        WordprocessingDocumentType.Document))
      {
        MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
        mainPart.Document = new Document();
        Run run = new Run(); 
        foreach (string currText in text) // Add text to run.
        {
          Text currLine = new Text(currText);
          run.AppendChild<Text>(currLine);
          run.AppendChild<CarriageReturn>(new CarriageReturn());
        }
        Paragraph paragraph = new Paragraph(run);
        Body body = new Body(paragraph);
        mainPart.Document.Append(body);
        RunProperties runProp = new RunProperties(); // Create run properties.
        RunFonts runFont = new RunFonts();           // Create font
        runFont.Ascii = "Arial";                     // Specify font family
        FontSize size = new FontSize();
        size.Val = new StringValue("48");  // 48 half-point font size
        runProp.Append(runFont);
        runProp.Append(size);
        run.PrependChild<RunProperties>(runProp);
        mainPart.Document.Save();
        wordDoc.Close();
      }
    }
