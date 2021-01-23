    public class GroceryList : MongoEntity<ObjectId>
    {
        public FacebookList Owner { get; set; }
        [BsonIgnore]
        public bool IsOwner { get; set; }
    }
