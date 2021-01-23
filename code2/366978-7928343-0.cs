    public Form2()
    {
       InitializeComponent();
    }
    public Form2(int id)
    {
        InitializeComponent();
        if(id == 101)
            textBox1.Text = "MAHESH";
    }
    public Form2(string name)
    {
        InitializeComponent();    
        textBox1.Text = name;
    }
