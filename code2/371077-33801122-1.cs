            try
            {
                using (System.IO.TextWriter tw = new System.IO.StreamWriter(@"C:\listViewContent.txt"))
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        tw.WriteLine(item.Text);
                        for (int a = 1; a <= 3; a++ ) //the 3 = number of subitems in a listview 
                        {
                            tw.WriteLine(item.SubItems[a].Text);
                        }
                    }
                }
            }
            catch {
                MessageBox.Show("TEXT FILE NOT FOUND");
            }
