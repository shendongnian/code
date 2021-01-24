    public IQueryable<SlotOrder> GetTest()
        {
            //Save record to table
            
            //After saving record
            var list = CommitLoad<SlotOrder>(EntityRelationships.Slot);
            return list;
        }
