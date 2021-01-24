    Application wApp = new Application();
    Documents wDocs = wApp.Documents;
    Document wDoc = wDocs.Add(@"source\path\source.docx", Type.Missing, Type.Missing, true);
    Range oRange = wDoc.Content;
    wDoc.SaveAs(@"destination\path\destination.docx");
    wDoc.Activate();
