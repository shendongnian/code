    private class CategoryItems
    {
      public string Category { get; set; }
      public string Item { get; set; }
      public CategoryItems(string category, string item)
      {
        this.Category = category;
        this.Item = item;
      }
      public override string ToString()
      {
        return this.Item;
      }
    }
    private List<string> categories = new List<string>();
    private List<CategoryItems> catItems = new List<CategoryItems>();
    private void Form1_Load(object sender, EventArgs e)
    {
      categories.Add("Cat 1");
      categories.Add("Cat 2");
      catItems.Add(new CategoryItems("Cat 1", "Cat 1 Item 1"));
      catItems.Add(new CategoryItems("Cat 1", "Cat 1 Item 2"));
      catItems.Add(new CategoryItems("Cat 2", "Cat 2 Item 1"));
      catItems.Add(new CategoryItems("Cat 2", "Cat 2 Item 2"));
      foreach (string cat in categories)
      {
        listBox1.Items.Add(cat);
      }
      listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      listBox2.Items.Clear();
      foreach (CategoryItems ci in catItems)
      {
        if (ci.Category == listBox1.SelectedItem.ToString())
          listBox2.Items.Add(ci);
      }
    }
