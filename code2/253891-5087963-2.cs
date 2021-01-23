    public Form2()
    {
        InitializeComponent();
    }
    
    public void button1_Click(object sender, EventArgs e)
    {
    //if subscribers exists
      if(SomeTextInSomeFormChanged != null)
      {
        SomeTextInSomeFormChanged(form2_textBox1, null);
      }
    }
