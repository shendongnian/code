     using (TransactionScope scope = new TransactionScope())
    {
        using (DataAccess.Document Access = new DataAccess.Document())
        {
            if (toSave.Document.Rows.Count > 0)
            {
                 Access.SaveDocument(docToSave);
            }
            if (toUpdate.Document.Rows.Count > 0)
            {
                 Access.UpdateEachDocument(docToUpdate);
            }
          scope.Complete();       
       }
       
    }
