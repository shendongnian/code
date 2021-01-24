    public Form1()
    {
        InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        int userVal1 = int.Parse(Form1.textBox1.Text);
        int userVal2 = int.Parse(Form1.textBox2.Text);
        int answer = (userVal1 * userVal2);
        MessageBox.Show("MPG: ", answer);
    }
