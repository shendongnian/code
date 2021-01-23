    private void Form1_Load(object sender, EventArgs e)
    {
      listBox1.Items.Add("Cat 1");
      listBox1.Items.Add("Cat 2");
      listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      listBox2.Items.Clear();
      switch (listBox1.SelectedItem.ToString())
      {
        case "Cat 1":
          {
            listBox2.Items.Add("Cat 1 Item 1");
            listBox2.Items.Add("Cat 1 Item 2");
            break;
          }
        case "Cat 2":
          {
            listBox2.Items.Add("Cat 2 Item 1");
            listBox2.Items.Add("Cat 2 Item 2");
            break;
          }
      }
    }
