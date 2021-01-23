    [CommandMethod("Test", CommandFlags.Session)]   
    public void Test() {   
      AddLineToDrawing();   
      AddCircleToDrawing();   
    }  
    private void AddLineToDrawing() {   
      CreateObjectOnBlockTable(
        new Line(new Point3d(0, 0, 0), new Point3d(10, 10, 0)));   
    }   
   
    private void AddCircleToDrawing() {   
      CreateObjectOnBlockTable(
        new Circle(new Point3d(0, 0, 0), new Vector3d(0, 0, 0), 10));   
    }   
    private void CreateObjectOnBlockTable(DBObject dbObject) { 
      using (var lockedDocument = Application.DocumentManager.MdiActiveDocument.LockDocument()) 
      using (var database = Application.DocumentManager.MdiActiveDocument.Database) 
      using (var transaction = database.TransactionManager.StartTransaction()) {
        // Open the block table for read 
        var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead); 
        
        // Open the block table record model space for write 
        var blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite); 
        blockTableRecord.AppendEntity(dbObject); 
        transaction.AddNewlyCreatedDBObject(dbObject, true); 
        transaction.Commit(); 
      } 
    } 
