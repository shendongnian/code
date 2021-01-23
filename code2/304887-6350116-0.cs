     public class EntityFoo
        {
            public string Bar { get; set; }
    
            public EntityFoo (string bar)
            {
                Bar = bar;
            }
        }
    
        public class EntityDumper //and the EntitySerializer
        {
            public static string Dump<T> (T entity)
            {
                return new TypeSerializer<T> ().SerializeToString (entity);
            }
    
            public static T LoadBack<T> (string dump)
            {
                return new TypeSerializer<T> ().DeserializeFromString (dump);
            }
        }
    
        public class dump_usage
        {
            public void start ()
            {
                string dump = EntityDumper.Dump (new EntityFoo ("Space"));
    
                EntityFoo loaded = EntityDumper.LoadBack<EntityFoo> (dump);
                Debug.Assert (loaded.Bar == "Space");
            }
        }
