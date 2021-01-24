                string inFile = @"Events.txt";
                var contents = File.ReadAllLines(inFile);
                // skip the header line
                var data = contents.Skip(1);
               var sorted = data.Select(line => new
                 {// Make sure that you use the index depend on your line
                  SortKey = DateTime.Parse(line.Split(',')[2]),
           
                  Line = line
                  }
                  ).OrderBy(x => x.SortKey);
                  File.WriteAllLines(inFile, lines.Take(1).Concat(sorted), Encoding.Default);
        
                //CLEARS EVERYTHING IN THE LISTVIEW
                listView1.Items.Clear();
        
                //OPENS THE DATA AGAIN IN THE LISTVIEW AFTER BEING SORTED
                foreach (var line in System.IO.File.ReadLines(inFile))
                {
                    // Split only the single line
                    string[] lineItems = line.Split(',');
        
                    ListViewItem listView1 = new ListViewItem();
                    listView1.Text = lineItems[0];
                    listView1.SubItems.Add(lineItems[1]);
                    listView1.SubItems.Add(lineItems[2]);
                    listView1.SubItems.Add(lineItems[3]);
                    listView1.SubItems.Add(lineItems[4]);
                    this.listView1.Items.Add(listView1);
                }
        
       
