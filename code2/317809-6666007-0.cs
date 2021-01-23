    string result;
    var reader=command.CreateReader();
    if (reader.Read()) {
      result=String.Join(",",Enumerable.Range(0,reader.FieldCount).Select(x=>reader.IsDbNull(x) ? String.Empty : reader[x].ToString()).ToArray());
    }
