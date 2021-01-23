    using (StreamWriter writer = new StreamWriter(@"C:\Desktop\test.txt"))
    {
        StringBuilder line = new StringBuilder();
        foreach (ListViewItem item in listView1.Items)
        {
            line.Clear();
            for (int i=0; i<item.SubItems.Count; i++)
            {
                if (i > 0)
                    line.Append("|");
                line.Append(item.SubItems[i].Text);
            }
            writer.WriteLine(line);
        }
    }
