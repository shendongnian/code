    public class MyInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(InheritanceMappingContext context)
        {        
            MyEntity entity = new MyEntity()
            {
                ...
            };
            context.MyEntities.Add(entity);
            context.SaveChanges();
        }
    }
