    // First Initiate the fixed columns with the 
    public void FormConstructor
    {
         InitializeComponent();
         listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);         
         listView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
         //OR
         listView.Columns[0].Width = 100;
         listView.Columns[2].Width = 200;
    }
    // Event on WindowSizechanged
    private void Form_SizeChanged(object sender, EventArgs e)
    {
        listView.Columns[1].Width = listView.Width - listView.Columns[0].Width - 
                                    listView.Columns[2].Width;
    }
    
