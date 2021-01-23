    var values = new Dictionary<string, string>() {
      {"LoginEmail", "LoginEmail"},
      {"Password", "Password"},
      {"ContactName", "ContactName"},
      {"City", "City"}
    };
    
    System.Func<string, string> key = p => String.Concat("?", p);
     
    var statement = string.Format("INSERT INTO registrations ({0}) VALUES ({1})", 
      string.Join(",", values.Values.ToArray()),
      string.Join(",", values.Keys.Select(key).ToArray())
    );
      
    //"INSERT INTO registrations (LoginEmail,Password,ContactName,City) VALUES (?LoginEmail,?Password,?ContactName,?City)"  
    
    foreach(var p in values) {
      command.Parameters.Add(key(p.Key), p.Value, SqlDbType.Text);
    }
    
    command.Prepare();
    command.ExecuteNonQuery();
    
    They may be other better classes for .NET mysql, apologies if so - I haven't used mysql in .NET
