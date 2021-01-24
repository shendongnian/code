    private DataTable SplitStringInto(string fldName, string txt, params string[] splitters) {
      DataTable dt = new DataTable();
      dt.Columns.Add(fldName, typeof(string));
      foreach (string s in txt.Split(splitters, StringSplitOptions.None)) 
        dt.Rows.Add(new object[] { s });
      return dt;
    }
