    public MainWindow()
    {
        InitializeComponent();
        btnSubmit.IsEnabled = false;
        txtFirstName.TextChanged += Program_MyEvent;
        txtSurName.TextChanged += Program_MyEvent;
        cboFruits.SelectionChanged += Program_MyEvent;
        cboSports.SelectionChanged += Program_MyEvent;
    }
    void Program_MyEvent(object sender, EventArgs e)
    {
        if (txtFirstName.Text.Length > 0 && txtSurName.Text.Length > 0 && cboFruits.SelectedIndex >= 0 && cboSports.SelectedIndex >= 0)
        {
            btnSubmit.IsEnabled = true;
        }
        else
        {
            btnSubmit.IsEnabled = false;
        }
    }
