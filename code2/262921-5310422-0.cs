    using (var context = new MyContext())
    {
        context.Attach(sketch);
        ObjectStateEntry entry = context.ObjectStateManager.GetObjectStateEntry(sketch);
        entry.SetModifiedProperty("Number");
        ...
        context.SaveChanges();
    }
