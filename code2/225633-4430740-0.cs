        static void Main(string[] args)
        {
            var entity = GetEntityByKey<Entity>(Guid.Empty);
        }
        private static T GetEntityByKey<T>(object key) where T : class 
        {
            using (var context = new ObjectContext("Name=ModelContainer"))
            {
                var set = context.CreateObjectSet<T>().EntitySet;
                var pk = set.ElementType.KeyMembers[0]; // careful here maybe count can be o or more then 0
                EntityKey entityKey = new EntityKey(set.EntityContainer.Name+"."+set.Name, pk.Name, key);
                return (T)context.GetObjectByKey(entityKey);
            }
        }
