    Public MyItem
    {
    public string Code;
    public string Name,
    public float Price;
    public bool inStock;
    
    }
    
    List<MyItem> myList = new List<MyItem>();
    
    private void button1_Click(object sender, EventArgs e)
    {
      MyItem temp = new MyItem()
      temp.Code=txtBox1.Text;
      temp.Name=(txtBox2.Text);
      temp.Price=(txtBox3.Text);
      temp.inStock=(txtBox4.Text);
      mylist.add(temp);
      txtBox1.Text = "";
      txtBox2.Text = "";
      txtBox3.Text = "";
      txtBox4.Text = "";
    }
