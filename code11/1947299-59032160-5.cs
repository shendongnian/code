    private readonly Data _data = new Data();
    public Form1()
    {
        InitializeComponent();
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        _data.Greeting = "Hello";
        var frm2 = new Form2(_data);
        frm2.Show();
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        var frm2 = new Form2(_data);
        frm2.Show();
    }
