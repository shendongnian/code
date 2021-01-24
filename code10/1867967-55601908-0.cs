    List<object> list = new List<object>();
    while (reader.Read()) {
        list.Add(new { id =  (int)reader["id"],
                       uid = (string)reader["uid"],
                       bet = (int)reader["bet"],
                       game = (string)reader["game"], });
    }
    
    string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);
