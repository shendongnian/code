            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("count", typeof(int));
            
            var str = "itemid/n3,itemid/n4";
            var items =
                str.Split(',').Select(
                    r =>
                    new
                        {
                            Id = r.Split(new[] {"/n"}, StringSplitOptions.RemoveEmptyEntries).First(),
                            Count = int.Parse(r.Split(new[] {"/n"}, StringSplitOptions.RemoveEmptyEntries).Last())
                        });
            foreach (var item in items)
            {
                var row = table.NewRow();
                row["id"] = item.Id;
                row["count"] = item.Count;
            }
