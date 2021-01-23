                DataTable t = new DataTable();
                DataColumn c1 = new DataColumn("Name", typeof(String));
                DataColumn c2 = new DataColumn("Date", typeof(DateTime));
                t.Columns.Add(c1);
                t.Columns.Add(c2);
                for (int i = 0; i < 10; i++)
                {
                    t.Rows.Add(new object[] {i.ToString(), DateTime.Now.AddHours(i * 2) });
                }
                dataGridView1.DataSource = t;
                dataGridView1.Columns[1].DefaultCellStyle.Format = "HH MM/dd/yyyy";
