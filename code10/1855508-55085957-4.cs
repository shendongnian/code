    public Form1()
    {
        InitializeComponent();
        DoSomething(DateTime.Now);
    }
    void DoSomething(DateTime date)
    {
        MessageBox.Show(date.ToString());
    }
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        DoSomething(dateTimePicker1.Value);
    }
