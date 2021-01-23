        [TestMethod]
        public void TestMethod1()
        {
            var matches = new[] 
            {
                new { displayName = "Sausage Roll", summary = "|Title: Network Coordinator|Location: Best Avoided|Department: Coordination|Email: Sausage.Roll@somewhere.com|" },
                new { displayName = "Hamburger Pattie",  summary = "|Title: Network Development Engineer|Location: |Department: Planning|Email: Hamburger.Pattie@somewhere.com|" },
            };
            IList<Person> persons = new List<Person>();
            foreach (var m in matches)
            {
                string[] fields = m.summary.Split('|');
                persons.Add(new Person { displayName = m.displayName, Title = fields[1], Location = fields[2], Department = fields[3] });
            }
            Assert.AreEqual(2, persons.Count());
        }
        public class Person
        {
            public string displayName { get; set; }
            public string Title { get; set; }
            public string Location { get; set; }
            public string Department { get; set; }
            /* etc. */
        }
