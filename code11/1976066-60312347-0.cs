    List<string> list = new List<string>() { "A", "B", "C", "D" };
    private void Form1_Load(object sender, EventArgs e)
    {
        listBox1.Size = new Size(120, 17);
    }
    int index = 0;
    private void btNext_Click(object sender, EventArgs e)
    {
        // clear the items
        listBox1.Items.Clear();
        // add next item
        listBox1.Items.Add(list[index]);
        index++;
        // check if is the last item
        if(index == list.Count)
        {
            // reset index
            index = 0;
        }
    }
