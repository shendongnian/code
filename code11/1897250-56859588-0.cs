    public Dictionary<string, int> GroupTot(DataTable dt, string[] groupBy, string tot){
   
      var d = new Dictionary<string, int>();
      foreach(DataRow ro in dt.Rows){
        string key = "";
        foreach(string col in groupBy)
          key += (string)ro[col] + '\n';
        if(!d.ContainsKey(key))
          d[key] = 0;
        d[key]+= (int)ro[tot];
      }
      return d;
    }
