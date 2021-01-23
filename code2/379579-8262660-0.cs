    public class MyDBInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        private MyContext _Context;
        protected override void Seed(MyContext context)
        {
            base.Seed(context);
            _Context = context;
            // We create database indexes
            CreateIndex("FieldName", typeof(ClassName));
            context.SaveChanges();
        }
        private void CreateIndex(string field, Type table)
        {
            _Context.Database.ExecuteSqlCommand(String.Format("CREATE INDEX IX_{0} ON {1} ({0})", field, table.Name));
        }    
    }	
