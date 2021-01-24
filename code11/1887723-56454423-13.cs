                var query =
                    from ce in c.AsEnumerable()
                    join le in lookup.AsEnumerable() on c.Field<Guid>("Campaign ID") equals le.Field<Guid>("Campaign ID") into cele
                    from lenull in cele.DefaultIfEmpty()
                    select new object[]
                    {
                      ce.Field<Guid>("Campaign ID"),
                      ce.Field<string>("Description"),
                      ce.Field<int>("Number"), //don't know how your table has null here, maybe <int?>
                      lenull?.Field<string>("Name")
                    };
                DataTable c = new DataTable(); //to hold results
                c.Columns.Add("Campaign ID", typeof(Guid)); 
                c.Columns.Add("Description"); 
                c.Columns.Add("Number", typeof(int)); 
                c.Columns.Add("Name");
                foreach (var at in query)
                    c.Rows.Add(at);
