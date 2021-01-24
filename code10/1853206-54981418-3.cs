    public Form1()
    {
        InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        int num1,num2;
        If(Int32.TryParse(textBox1.Text,out num1) && Int32.TryParse(textBox2.Text,out num2))
        {
            int answer = num1 * num2;
            string output = "MPG: "+ answer.ToString();
            MessageBox.Show(output);
        }
        
    }
