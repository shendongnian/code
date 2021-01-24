    private BindingSource bs = new BindingSource();
    public Form1()
    {
        InitializeComponent();
        _vm = new Form1VM();
        bs.DataSource = _vm;
    }
___
    private void BindControl(Control control, string propertyName)
    {
        control.DataBindings.Clear();
        control.DataBindings.Add(nameof(control.Text), bs, propertyName, true, DataSourceUpdateMode.OnValidation);
    }
