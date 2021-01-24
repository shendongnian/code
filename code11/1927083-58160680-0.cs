    private void Form1_Load(object sender, EventArgs e)
    {
        listView.View = View.Details;
        listView.CheckBoxes = true;
        // Add columns
        listView.Columns.Add("Col1", 150, HorizontalAlignment.Left);
        listView.Columns.Add("Col2", 150, HorizontalAlignment.Left);
        for (int i = 1; i < 5; i++)
        {
            var item = new ListViewItem();
            item.Text = i.ToString();
            item.SubItems.Add((i * 10).ToString());
            listView.Items.Add(item);
        }
    }
    List<string> list = new List<string>();
    private void button1_Click(object sender, EventArgs e)
    {
        list.Clear();
        foreach (ListViewItem item in listView.Items)
        {
            if (item.Checked == true)
            {
                list.Add(item.Text + ", " + item.SubItems[1].Text);
            }
        }
        using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(@"D:\test.txt"))
        {
            foreach (string line in list)
            {
                file.WriteLine(line);
            }
        }
    }
