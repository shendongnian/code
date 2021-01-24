    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        ComboBox cb = new ComboBox();
        cb.DropDownStyle = ComboBoxStyle.DropDownList;
        cb.AutoCompleteSource = AutoCompleteSource.ListItems;
        cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cb.Location = new System.Drawing.Point(20, 50);
        cb.KeyDown += new System.Windows.Forms.KeyEventHandler(CBKeyDown);
        cb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(CBPreviewKeyDown);
        cb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CBKeyPress);
        this.Controls.Add(cb);
        List<string> someThings = new List<string>();
        someThings.Add("An item");
        someThings.Add("Another item");
        cb.DataSource = someThings;
    }
    private void CBPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
                if (e.Control)
                {
                    e.IsInputKey = true;
                }
                break;
        }
        // Return back drop down height, in case ctrl + enter keys were pressed
        (sender as ComboBox).DropDownHeight = 100;
    }
    private void CBKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
                if (e.Control)
                {
                    // Do application specific stuff
                    e.Handled = true;
                    // Set drop down height to 1, in order to set height
                    // that looks like drop down is not showed at all (only 1 pixel)
                    (sender as ComboBox).DropDownHeight = 1;
                }
                break;
        }
    }
    private void CBKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\n')
        {
            e.Handled = true;
        }
    }
