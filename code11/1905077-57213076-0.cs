    DataTable dt = new DataTable();
    dt.Columns.Add("something");
    dt.Columns.Add("name");
    dt.Columns.Add("displayname");
    dt.Columns.Add("location");
    dt.Columns.Add("ID");
    string csv = @"someth1,{jon}{jonno}{newyork}{1}
    Someth2,{jane}{janey}{paris}{2}";
    foreach(string line in csv.Split()){
      string bits = line.Split(',');
      List<string> itm = new List<string>();
      itm.Add(bits[0]);
      itm.AddRange(bits[1].Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      dt.Rows.Add(itm.ToArray());
    }
