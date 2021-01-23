    public Form1(Form parent)
    {
        InitializeComponent();
        _parent = parent;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (_parent != null)
            _parent.Focus();
    }
