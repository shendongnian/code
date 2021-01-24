    public void myFunction ()
    {
        Expression<Func<ItemType, bool>> expression = x => x.Id == 5 && x.Desc.Contains("foos");
        var items = GetAllItems()
            .Where(expression)
            .ToList();
        var res = GenericBeforeSaveValidation(expression);
    }
    
    public IQueryable<ItemType> GenericBeforeSaveValidation(Expression<Func<ItemType, bool>> exp)
    {
         //some generic stuff before 
         return sourceItems.Where(exp);
    }
