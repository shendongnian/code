    public class YourCollectionDAO : MongoDBConnect
    {
        public YourCollectionDAO()
        {
        }
        public YourCollection Find(string yourCollectionID)
        {
            var collection = this.database.GetCollection<User>("YourCollection");
            Expression<Func<YourCollection, bool>> filter = x => x.yourCollectionID == yourCollectionID;
            IList<YourCollection> filtering = collection.Find(filter).ToList();
            var yourCollectionItem = filtering.Where(x => x.yourCollectionID == yourCollectionID).FirstOrDefault();
            return yourCollectionItem;
        }
    }
