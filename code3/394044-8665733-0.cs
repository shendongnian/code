     DataTable dt = new DataTable();
     dt.Columns.Add(new DataColumn("Check", typeof(System.Web.UI.WebControls.CheckBox)));
     DataRow dr = dt.NewRow();
     CheckBox ck = new CheckBox();
     ck.Checked = true;
     dr["Check"] = ck;
     dt.Rows.Add(dr);
