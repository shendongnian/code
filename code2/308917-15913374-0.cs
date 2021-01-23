    class MyModel {
        public string MyField1 { get; set; }
        public string MyField2 { get; set; }
        // ...
    }
    //...
    using System.Reflection;
    var sql = "SELECT FROM foo WHERE bar=baz ORDER BY ";
    var sorts = new List<string>();
    // sortParams is a IDictionary<string, string> containing
    // user input like {"MyField1", "Asc"}
    foreach (var param in sortParams)
    {
        foreach (var prop in typeof(MyModel).GetProperties())
        {
            if (param.Key.Equals(prop.Name))
            {
                sorts.Add(prop.Name + (param.Value.Equals("Asc") ? " ASC" : " DESC"));
            }
        }
    }
    sql += string.join(",", sorts);
