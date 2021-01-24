    public void GroupTot(DataTable dt, string[] groupBy, string tot){
   
      var d = new Dictionary<string, int>();
      var dc = dt.Columns.Add("Total_" + tot, typeof(int[]));
      foreach(DataRow ro in dt.Rows){
        string key = "";
        foreach(string col in groupBy)
          key += (string)ro[col] + '\n'; //build a grouping key from first and last name
        if(!d.ContainsKey(key)) //have we seen this name pair before?
          d[key] = new int[1]; //no we haven't, ensure we have a tracker for our total, for this first+last name
        d[key][0] += (int)ro[tot]; //add the total
        ro[dc] = d[key]; //link the row to the total tracker
      }
    }
