    public class History : MongoDocument
    {
       // here you have some other properties, and you have a list of objects
       public Guid Guid { get; private set; }
       public List<SOME_OBJECT> NAME_OF_THE_ARRAY { get; set; }
    }
