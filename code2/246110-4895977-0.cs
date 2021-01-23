    [BsonIgnoreExtraElements]
    public class GroceryList : MongoEntity<ObjectId>
    {
        public FacebookList Owner { get; set; }
        public bool? IsOwner { get; set; }
    }
