    public Form2(string s)
    {
        InitializeComponent();
        listBox1.Items.Add(s);
    }
    public void AddNewItem(string s)
    {
        listBox1.Items.Add(s);
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    { 
    }
