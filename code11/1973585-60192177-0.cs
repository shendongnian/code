    public MainWindow()
    {
        InitializeComponent();
        btn1.IsEnabled = false;
        txtBox1.TextChanged += Program_MyEvent;
        txtBox2.TextChanged += Program_MyEvent;
        cbo1.SelectionChanged += Program_MyEvent;
        cbo2.SelectionChanged += Program_MyEvent;
    }
    void Program_MyEvent(object sender, EventArgs e)
    {
        if (txtBox1.Text.Length > 0 && txtBox2.Text.Length > 0 && cbo1.SelectedIndex >= 0 && cbo2.SelectedIndex >= 0)
        {
            btn1.IsEnabled = true;
        }
        else
        {
            btn1.IsEnabled = false;
        }
    }
