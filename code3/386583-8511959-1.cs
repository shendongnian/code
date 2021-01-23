    [PetaPoco.TableName("le_users")]
    [PetaPoco.PrimaryKey("id")]
    public class UserRecord
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
    }
    ...
    // Create a PetaPoco database object
    PetaPoco.Database db = new PetaPoco.Database(dbconnection);
    // Insert a record
    UserRecord rec = new UserRecord();
    rec.first_name = "Hunter";
    rec.last_name = "Thompson";
    db.Insert(rec);
