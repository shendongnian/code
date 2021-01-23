    public Form1()
    {
        InitializeComponent();
        private TextBox[] TextBoxes = {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6};
        private List<string> storeItems = new List<string>();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var buffer = new StringBuilder();
        foreach(var textBox in textBoxes)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.BackColor = Color.FromName("LightCoral");
                MessageBox.Show("This item cannot be left blank");
                textBox.Focus();
                return;
            }
            result.Append(textBox.Text);
        }
        var result = buffer.ToString();
        storeItems.Add(result);
        System.IO.File.AppendAllText(@"C:\Users\v\Desktop\text.txt", Environment.NewLine + result);
    }
