    public class MyContext : DbContext
    {
        public void Test()
        {            
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            var mdw = objectContext.MetadataWorkspace;
            var items = mdw.GetItems<EntityType>(DataSpace.CSpace);
            foreach (var i in items)
            {
                Console.WriteLine("Class Name: {0}", i.Name);
                Console.WriteLine("Key Property Names:");
                foreach (var key in i.KeyMembers)
                {
                    Console.WriteLine(key.Name);
                }
            }
     }
