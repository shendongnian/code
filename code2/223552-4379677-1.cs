    private void Form1_Load(object sender, EventArgs e)
    {
       userControl1.ValueChanged += userControl11_ValueChanged;
       userControl11.Value = 100;
    }
    private void userControl11_ValueChanged()
    {
        MessageBox.Show(userControl11.Value.ToString());
    }
