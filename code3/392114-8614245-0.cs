           DataSet ds = new DataSet();
            ds.ReadXml(@"...\\..\\Sites.xml");
            int count = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string s1 = dr[0].ToString(); 
                string s2 = dr[1].ToString();
                TimeSpan ts1 = DateTime.ParseExact(s1, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                TimeSpan ts2 = DateTime.ParseExact(s2, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                TimeSpan now = DateTime.Now.TimeOfDay;
                if (ts1.Hours >= 8 && ts2.Hours <= 22)
                {
                   ds.Tables[0].Rows[count][2] = "OK";
                }
                else
                {
                    ds.Tables[0].Rows[count][2] = "NOK";
                }
                count++;
            }
            grdvw_wnfrm.DataSource = ds.Tables[0];
            for (int icount = 0; icount < grdvw_wnfrm.RowCount-1; icount++)
            {
                DataGridViewRow theRow = grdvw_wnfrm.Rows[icount];
                if (theRow.Cells[2].Value.ToString() == "OK")
                    theRow.Cells[2].Style.BackColor = Color.Green;
                else
                    theRow.Cells[2].Style.BackColor = Color.Red;
            }
        }
