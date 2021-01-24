     var list = new List<string>();
            foreach(var item in listBox1.Items)
            {
                list.Add(item.ToString());
            }
            var r = from b in list
                    group b by b into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            foreach(var x in q)
            {
                MessageBox.Show("value: " + b.Value + " Count:" + b.Count);
            }
