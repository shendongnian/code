    var list = dataGridView1.Rows.OfType<DataGridViewRow>()
                        .Select(x => x.Cells["FullName"].Value);
            var q = from x in list
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { FullName = g.Key, Count = count };
            foreach (var item in q)
            {
                dataGridView2.Rows.Add(new object[] { item.FullName, item.Count });
            }
