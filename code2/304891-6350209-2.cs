    // A test object that needs to be serialized.
    [Serializable()]		
    public class BaseEntity
    {
        public int member1;
        public string member2;
        public string member3;
        public double member4;
    
        // A field that is not serialized.
        [NonSerialized()] public MyRuntimeType memberThatIsNotSerializable; 
    
        public TestSimpleObject()
        {
            member1 = 11;
            member2 = "hello";
            member3 = "hello";
            member4 = 3.14159265;
            memberThatIsNotSerializable = new Form ();
        }
        
        public MemoryStream Backup ()
        {
           return EntityBackupServices.Backup (this);
        }
    }
