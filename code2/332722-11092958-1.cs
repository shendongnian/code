    [CommandMethod("LayerIterator")]
    public static void LayerIterator_Method()
    {
        Database database = HostApplicationServices.WorkingDatabase;
        using (Transaction transaction = database.TransactionManager.StartTransaction())
        {
            SymbolTable symTable = (SymbolTable)transaction.GetObject(database.LayerTableId, OpenMode.ForRead);
            foreach (ObjectId id in symTable)
            {
                LayerTableRecord symbol = (LayerTableRecord)transaction.GetObject(id, OpenMode.ForRead);
    
                //TODO: Access to the symbol
                MgdAcApplication.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Format("\nName: {0}", symbol.Name));
            }
    
            transaction.Commit();
        }
    }
