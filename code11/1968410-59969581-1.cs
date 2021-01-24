    public Form1()
       {
    InitializeComponent();
    button1.Click += button_Click;
    button2.Click += button_Click;
    button3.Click += button_Click;
     }
    private void button_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        bc(btn.Text);
    }
