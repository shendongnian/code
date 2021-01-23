    public class CustomEntities : MyEntities
    {
        public new IQueryable<Foo> Foos
        {
            get { return base.Foos.Where(f => f.Deleted == 0); }
        }
    }
    ...
    using (var context = new CustomEntities())
    {
        var foo = context.Foos.Where(f => f.Id == 1).SingleOrDefault();
    }
