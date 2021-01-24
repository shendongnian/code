    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
    {
        string line = String.Empty;
        StringBuilder sb = new StringBuilder();
        // this.textBox1.Text = sr.ReadToEnd(); // remove it, listview working
        while ((line = sr.ReadLine()) != null)
        {
            string[] data = line.Split(new char[0]);
            ListViewItem item = new ListViewItem
            {
                Text = data[0]
            };
            item.SubItems.Add(data[1]);
            listView1.Items.Add(item);
            sb.AppendLine(line);
        }
        this.textBox1.Text = sb.ToString();
    }
