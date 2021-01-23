    MyClass myClass = new MyClass("one", "two");
    
    public Form1()
    {
        InitializeComponent();
        textBox1.DataBindings.Add("Text", myClass, "Text1", false, DataSourceUpdateMode.OnPropertyChanged);
        textBox2.DataBindings.Add("Text", myClass, "Text2", false, DataSourceUpdateMode.OnPropertyChanged);
    }
    
    private void saveButton_Click(object sender, EventArgs e)
    {
        // your object should already have new text values entered.
        // Save your object!
    
        //myClass.Text1 = textBox1.Text;
        //myClass.Text2 = textBox2.Text;
        //textBox1.DataBindings["Text"].WriteValue();
        //textBox2.DataBindings["Text"].WriteValue();
    }
