        class DomainObject
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public string Type { get; set; }
            public string Version { get; set; }
        }
        class GroupedDomainObject
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public string Type { get; set; }
            public IEnumerable<string> Versions { get; set; }
        }
        private IEnumerable<GroupedDomainObject> ConvertDataTableToGroupedDomainObject(DataTable dataTable)
        {
            IEnumerable<DomainObject> complexList = dataTable.Select()  // DataTable Select turns it into an IEnumerable
                .Select(r => new DomainObject  // a linq Select turns it into your DomainObject
                {
                    Name = r["Name"].ToString(),
                    Year = Convert.ToInt16(r["Year"]),
                    Type = r["Type"].ToString(),
                    Version = r["Version"].ToString()
                });
            // now use linq GroupBy to turn it into (your 64) distinct Groups
            return complexList.GroupBy(i => new { i.Name, i.Year, i.Type }, (key, items) => new GroupedDomainObject
            {
                Name = key.Name,
                Year = key.Year,
                Type = key.Type,
                Versions = items.Select(o => o.Version)
            });
        }
        private void testConversionToGroupedDomainObject()
        {
            var mike = new DataTable();
            mike.Columns.Add("Name", typeof(string));
            mike.Columns.Add("Year", typeof(int));
            mike.Columns.Add("Type", typeof(string));
            mike.Columns.Add("Version", typeof(string));
            mike.Rows.Add("NameOne", 2019, "TypeA", "Version1");
            mike.Rows.Add("NameOne", 2018, "TypeB", "Version2");
            mike.Rows.Add("NameOne", 2018, "TypeB", "Version3");
            mike.Rows.Add("NameOne", 2018, "TypeB", "Version4");
            mike.Rows.Add("NameTwo", 2019, "TypeA", "Version1");
            mike.Rows.Add("NameTwo", 2018, "TypeB", "Version2");
            mike.Rows.Add("NameTwo", 2018, "TypeB", "Version3");
            mike.Rows.Add("NameTwo", 2018, "TypeB", "Version4");
            var result = ConvertDataTableToGroupedDomainObject(mike);
            Debug.Assert(mike.Rows.Count == result.Select(r => r.Versions).Count());
        }
