lang-cs
using (Database db = new Database())
{
    Thing thing = new Thing();
    string sql = @"insert into Things() 
                    values ();
                    select ID, Number
                    from Things
                    where @@rowcount > 0 and ID = scope_identity();";
    
    KeyMapper recentlyRecevedKeys = await db
        .Database
        .SqlQuery<KeyMapper>(sql)
        .FirstAsync();
    
    thing.ID = recentlyRecevedKeys.ID;
    thing.Number = recentlyRecevedKeys.Number;  
}
// Nested class
private class KeyMapper
{
    public int ID { get; set; }
    public string Number { get; set; }
}
