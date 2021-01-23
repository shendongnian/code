    protected void Button1_Click(object sender, EventArgs e)
            {
    
                List<myTable> myTables = new List<myTable>();
                for (int month = 1; month < 20; month++)
                {
                    for (int day = 1; day < 20; day++)
                    {
                        myTables.Add(new myTable { PersonName = "Person " + month.ToString() + " " + day.ToString(), ApplicationReceivedDate = new DateTime(2011, month, day) });
                    }
                }
    
                string searchName = "Person";
                DateTime searchDateFrom = Convert.ToDateTime(Request.Form["ReceivedDateFrom"]);
                DateTime searchDateTo = Convert.ToDateTime(Request.Form["ReceivedDateTo"]);
    
                var Results = (from va in myTables
                               where va.PersonName.Contains(searchName)
                                       && va.ApplicationReceivedDate > searchDateFrom
                                           && va.ApplicationReceivedDate < searchDateTo
                               select va).ToList();
            }
    
            public class myTable
            {
                public string PersonName { get; set; }
                public DateTime ApplicationReceivedDate { get; set; }
            }
