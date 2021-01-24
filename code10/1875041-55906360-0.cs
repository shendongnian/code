             ListView listView1 = new ListView();
             listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
             listView1.View = View.Details;
             listView1.GridLines = true;
             listView1.Columns.Add("TD");
             listView1.Columns.Add("AD");
             listView1.Columns.Add("CT", -2);
             var sValues = new string[] { "10;155.4587;0.01", "11;156.4587;0.02", "12;157.4587;0.03" };
             var values = sValues.Select(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                               .Select(x =>
                               {
                                  var listViewItem = new ListViewItem(x[0]);
                                  listViewItem.SubItems.Add(x[1]);
                                  listViewItem.SubItems.Add(x[2]);
                                  return listViewItem;
                               });
             listView1.Items.AddRange(values.ToArray());
