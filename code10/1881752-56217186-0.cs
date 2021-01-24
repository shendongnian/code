            DataTable dt = new DataTable();
            dt.Columns.Add("Column1", Type.GetType("System.String"));
            dt.Columns.Add("Column2", Type.GetType("System.String"));
            GridView1.DataSource = dt;
            GridView1.DataBind();
