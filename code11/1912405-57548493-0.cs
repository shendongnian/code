    public void createChecklist()
    {
        Application app = new Application();
        app.Visible = true;
        Document doc = app.Documents.Add();
        Paragraph para = doc.Paragraphs.Add();
        Range rng = para.Range;
        ContentControl checkbox = rng.ContentControls.Add(WdContentControlType.wdContentControlCheckBox);
        rng.MoveEnd(WdUnits.wdCharacter, -1);
        rng.InsertAfter(" sdjsakd");
        doc.SaveAs2("C:\\tmp\\checklist.docx");
      //Release the COM objects and clean up
        checkbox = null;
        rng = null;
        para = null;
        doc = null;
        app.Quit();
        app = null;
        GC.Collect(); GC.AwaitPendingFinalizers();
        GC.Collect(); GC.AwaitPendingFinalizers();
    }
