C#
public LiteDatabase OpenDatabase()
{
    var db = new LiteDatabase("data.db");
    
    // check for database version
    if (db.UserVersion == 0)
    {
        var col = db.GetCollection("mycollection");
        
        foreach(var doc in col.FindAll())
        {
            doc["NewProperty"] = doc["OldProperty"];
            
            doc.RemoveKey("OldProperty");
            
            col.Update(doc);
        }
        
        db.UserVersion = 1;
    }
    
    return db;
}
