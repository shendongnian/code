    public tblPersoon GetPersoonByID(string id)
    {
        var context = new DataClasses1DataContext();
        var query = context.tblPersoons.Where(p => p.id == id).Single();
        // ...
