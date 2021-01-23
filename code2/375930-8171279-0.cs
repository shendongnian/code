                var cmd = new SqlCommand("SELECT * FROM TAGS$",connectionToSQL);                 
                var da = new SqlDataAdapter(cmd);
                var b = new SqlCommandBuilder(da);
                //dt.Rows[3][2] = "20";
                foreach (DataRow r in dt.Rows)
                {
                    r.SetModified();
                }
                da.Update(dt);
