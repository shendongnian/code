    DataTable dt = new DataTable();
    dt.Columns.Add("something");
    dt.Columns.Add("info", typeof(string[]));
    string csv = @"someth1,{jon}{jonno}{newyork}{1}
    someth2,{jane}{janey}{paris}{2}";
    foreach(string line in csv.Split()){
      string bits = line.Split(',');
      string info = bits[1].Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      dt.Rows.Add(new object[] { bits[0], info });
    }
