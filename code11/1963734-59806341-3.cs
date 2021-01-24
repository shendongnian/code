    public IQueryable<SlotOrder> GetTest()
        {
            //Save record to table
            
            //After saving record, savechanges + load all
            var list = CommitLoad<SlotOrder>();
            return list;
        }
