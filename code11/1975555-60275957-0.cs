      DateTime time1 = DateTime.Parse("08:00:00");
            var result = Convert.ToDateTime(time1);
            string test = result.ToString("hh:mm:ss");
            foreach (DataRow pRow in dtDaily.Rows)
            {
                DateTime d= DateTime.Parse(pRow["startdate"].ToString());
                 if (d > time1)
                {
                    pRow["enddate"] = d - time1;
                    MessageBox.Show("sanjay" + pRow["enddate"]);
                }
            }
