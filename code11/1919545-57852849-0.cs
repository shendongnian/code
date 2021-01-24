    public void myFunction ()
    {
        Func<"itemType", bool> expression = x => x.Id == 5 && x.Desc.Contains("foos");
        var items = GetAllItems()
                           .Where(expression)
                           .ToList();
        var res = GenericBeforeSaveValidation(expression);
    }
    
    public IQueryable<T> GenericBeforeSaveValidation(Func<"itemType", bool> exp)
    {
         //some generic stuff before 
         return sourceItems.Where(exp);
    }
