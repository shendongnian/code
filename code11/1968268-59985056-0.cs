    ObjectIdCollection XRefs = new ObjectIdCollection();
    
    Database db = HostApplicationServices.WorkingDatabase;
    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
    	BlockTable blocks = tr.GetObject(db.BlockTableId, OpenMode.ForRead, false) as BlockTable;
    	foreach (ObjectId blockId in blocks)
    	{
    		BlockTableRecord bx = tr.GetObject(blockId, OpenMode.ForRead, false) as BlockTableRecord;
    		if (bx.IsFromExternalReference)
    		{
    			ObjectIdCollection references = bx.GetBlockReferenceIds(true, true);
    			foreach (ObjectId ref in references)
    			XRefs.Add (ref)
    		}
    	}
        tr.Dispose()
    }
