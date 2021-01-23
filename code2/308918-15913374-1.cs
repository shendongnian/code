    class MyModel {
        public string MyField1 { get; set; }
        public string MyField2 { get; set; }
        // ...
    }
    //...
    using System.Reflection;
    // sortBy = "MyField1"
    // sortDirection = "Asc";
    var sql = "SELECT FROM foo WHERE bar=baz ORDER BY ";
    foreach (var prop in typeof(MyModel).GetProperties())
    {
        if (sortBy.Equals(prop.Name))
        {
            sql += (prop.Name + (sortDirection.Value.Equals("Asc") ? " ASC" : " DESC"));
            break;
        }
    }
    
