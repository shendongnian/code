    public MyForm()
    {
        InitializeComponent();
        var labels = Enumerable.Range(0, 100)
                               .Select(i => new Label { Text = i.ToString() })
                               .ToArray();
    
        flowLayoutPanel1.Controls.AddRange(labels);
    }
