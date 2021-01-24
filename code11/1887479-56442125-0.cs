                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Keys", typeof(List<int>));
                dt.Rows.Add(new object[] { 1, new List<int>() {1, 3, 4}});
                dt.Rows.Add(new object[] { 1, new List<int>() {1, 2, 3}});
                dt.Rows.Add(new object[] { 1, new List<int>() {1, 5}});
                dt.Rows.Add(new object[] { 3, new List<int>() {2, 5}});
                dt.Rows.Add(new object[] { 4, new List<int>() {1, 2, 3, 4}});
                dt.Rows.Add(new object[] { 3, new List<int>() {2, 5}});
                dt.Rows.Add(new object[] { 3, new List<int>() {5, 1}});
                dt.Rows.Add(new object[] { 1, new List<int>() {3, 6}});
                dt.Rows.Add(new object[] { 1, new List<int>() {6, 1}}); 
                var temp = dt.AsEnumerable()
                    .SelectMany(x => x.Field<List<int>>("Keys").Select(y => new {key = y, value = x.Field<int>("Id")}).ToList()).ToList();
                var counts = temp.GroupBy(x => x.key).Select(x => new { key = x.Key, count = x.Count() }).ToList();
