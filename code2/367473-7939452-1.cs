    using (TransactionScope scope1 = new TransactionScope())
    {
        // Copy a file
        fileMgr.Move(srcFileName, destFileName);
    
        
    
        try
        {
            // Insert a database record
            dbMgr.ExecuteNonQuery(insertSql);
            scope1.Complete();
        } catch(Exception) {
            fileMgr.Move(destFileName, srcFileName);
        }
    }
