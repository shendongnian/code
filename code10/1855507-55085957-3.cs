    public Form1()
    {
        InitializeComponent();
        dateTimePicker1.Value = DateTime.Now;
    }
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        MessageBox.Show(date.ToString());
    }
