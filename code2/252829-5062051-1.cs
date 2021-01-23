    [TestMethod]
        public void TestMethod1()
        {
            List<myTable> myTables = new List<myTable>();
            for (int month = 1; month < 10; month++)
            {
                for (int day = 1; day < 20; day++)
                {
                    myTables.Add(new myTable { PersonName = "Person " + month.ToString() + " " + day.ToString(), ApplicationReceivedDate = new DateTime(2011, month, day) });
                }
            }
            string searchName = "Person";
            DateTime searchDateFrom = Convert.ToDateTime("2011-01-02");
            DateTime searchDateTo = Convert.ToDateTime("2011-01-03");
            var Results = (from va in myTables
                           where va.PersonName.Contains(searchName)
                                   && va.ApplicationReceivedDate >= searchDateFrom
                                       && va.ApplicationReceivedDate < searchDateTo
                           select va);
            Assert.AreEqual(Results.Count(), 1);
        }
        public class myTable
        {
            public string PersonName { get; set; }
            public DateTime ApplicationReceivedDate { get; set; }
        }
