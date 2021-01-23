    public interface ISortableEntity
    {
        int ID { get; set; }
        int SortOrder { get; set; }
    }
     public class DataFunctions
    {
        public static void MoveUp(string dbName, int valID)
        {
            var db = //Get your context here;
            List<KeyValuePair<string, object>> keys = new List<KeyValuePair<string, object>>();
            keys.Add(new KeyValuePair<string, object>("ID", valID));
            ISortableEntity entity = db.GetObjectByKey(new System.Data.EntityKey(dbName, keys)) as ISortableEntity;
            if (entity != null)
            {
                entity.SortOrder += 1;
            }
            db.SaveChanges();
        }
    }
