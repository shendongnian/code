    public Form1()
    {
        InitializeComponent();
        listBox1.Click += OnListBoxItemClick;
    }
    private void OnListBoxItemClick(object sender, EventArgs e)
    {
        var form2 = new Form2(listBox1.SelectedItem);
        form2.ShowDialog();
    }
