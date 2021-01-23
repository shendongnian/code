    Document doc = Application.DocumentManager.MdiActiveDocument;
    Database db = doc.Database;
    Editor ed = doc.Editor;
    PromptSelectionResult psr = ed.GetSelection();
    if (psr.Status != PromptStatus.OK) return;
    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
        foreach (SelectedObject so in psr.Value)
        {
            var dbo = tr.GetObject(so.ObjectId, OpenMode.ForRead);
            //...
        }
        tr.Commit();
    }
            
