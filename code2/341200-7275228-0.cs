    partial class MyEntities
    {
        public IQueryable<Foo> ActiveFoos
        {
            return Foos.Where(f => f.Deleted == 0);
        }
    }
    ...
    using (var context = new MyEntities())
    {
        var foo = context.ActiveFoos.Where(f => f.Id == 1).SingleOrDefault();
    }
