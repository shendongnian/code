    using (SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-IIBSL6N;Initial Catalog=sales_management;Integrated Security=True"))
            {
                if(searchplate.MaskFull==true)
                {
                    SqlDataAdapter sqlad = new SqlDataAdapter("select * From Vehicle  ", sqlconn);
                    DataTable dtbl = new DataTable();
                    sqlad.Fill(dtbl);
                    DataView dv = dtbl.DefaultView;
                    dv.RowFilter = string.Format("Plate_Number like '%{0}%'", searchplate.Text);
                    vehiclegrid.DataSource = dv.ToTable();  }
                }
