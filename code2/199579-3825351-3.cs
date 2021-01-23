    private void CreateObjectOnBlockTable(DBObject dbObject) {
      PerformActionOnBlockTable((transaction, blockTableRecord) => {
        blockTableRecord.AppendEntity(dbObject);  
        transaction.AddNewlyCreatedDBObject(dbObject, true);    
      });
    }
     
    private void PerformActionOnBlockTable(Action<Transaction, BlockTableRecord> action) {  
      using (var lockedDocument = Application.DocumentManager.MdiActiveDocument.LockDocument())  
      using (var database = Application.DocumentManager.MdiActiveDocument.Database)  
      using (var transaction = database.TransactionManager.StartTransaction()) { 
        // Open the block table for read  
        var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);  
     
        // Open the block table record model space for write  
        var blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);  
     
        // Run specific logic
        action(transaction, blockTableRecord);
        
        transaction.Commit();  
      }  
    }  
