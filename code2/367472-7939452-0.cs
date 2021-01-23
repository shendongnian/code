    using (TransactionScope scope1 = new TransactionScope())
    {
        // Copy a file
        fileMgr.Move(srcFileName, destFileName);
    
        // Insert a database record
        dbMgr.ExecuteNonQuery(insertSql);
    
        try
        {
            scope1.Complete();
        } catch(Exception) {
            fileMgr.Move(destFileName, srcFileName);
        }
    }
