	DataTable dt = new DataTable();
        dt.Columns.Add("User");
        dt.Columns.Add("extPhone_no_1");
        dt.Columns.Add("extPhone_no_2");
        dt.Columns.Add("extPhone_no_3");
        dt.Rows.Add("Mrs.Cheung", "282", null, null);
        dt.Rows.Add("Mrs.Cheung", "283", null, null);
        dt.AcceptChanges();
        String strextPhone_no_1 = dt.AsEnumerable()
              .Select(row => row["extPhone_no_1"].ToString())
              .Aggregate((s1, s2) => String.Concat(s1, "," + s2));
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("User");
        dtNew.Columns.Add("extPhone_no_1");
        dtNew.Columns.Add("extPhone_no_2");
        dtNew.Columns.Add("extPhone_no_3");
        dtNew.Rows.Add("Mrs.Cheung", strextPhone_no_1, null, null);
    dtNew.AcceptChanges();
