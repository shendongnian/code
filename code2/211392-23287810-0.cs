    using Castle.ActiveRecord;
     
    [ActiveRecord("entity"), JoinedBase]
    public class Entity : ActiveRecordBase
    {
        private int id;
        private string name;
        private string type;
     
        public Entity()
        {
        }
     
        [PrimaryKey]
        private int Id
        {
            get { return id; }
            set { id = value; }
        }
     
        [Property]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
     
        [Property]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
     
        public static void DeleteAll()
        {
            DeleteAll(typeof(Entity));
        }
     
        public static Entity[] FindAll()
        {
            return (Entity[]) FindAll(typeof(Entity));
        }
     
        public static Entity Find(int id)
        {
            return (Entity) FindByPrimaryKey(typeof(Entity), id);
        }
    }
