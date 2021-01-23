    public MyForm()
    {
        // other code possibly here
        InitializeComponent();
        // and now add the event handler:
        tbxAnswer.KeyUp += new KeyEventHandler(tbxAnswer_KeyUp);
    }
    private void tbxAnswer_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == (char)13)
        {
            MessageBox.Show("Hello");
        }
    }
