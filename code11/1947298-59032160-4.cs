    private readonly Data _data;
    public Form2(Data data) // Note that now, we pass a Data object, not a Form
    {
        InitializeComponent();
        _data = data;
        textBox1.Text = _data.Greeting;
    }
    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
        _data.Greeting = textBox1.Text; // Stores back text box edits to the Data object.
    }
