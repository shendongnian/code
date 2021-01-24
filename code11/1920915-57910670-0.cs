    private JsonReport _lastItemTag;
    
    public Form1()
    {
        InitializeComponent();
    }
    
    private void ReportTemplateManager_Load(object sender, EventArgs e)
    {
        // Initialize context menu for template control
        ContextMenu cm = new ContextMenu();
        cm.MenuItems.Add("Load", new EventHandler(LoadReport_Click));
        template_listview.ContextMenu = cm;
    }
    
    private void LoadReport_Click(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        _lastItemTag = menuItem.Tag as JsonReport;
        
        if (_lastItemTag != null)
        {
            Console.WriteLine("Loading"); // This get executed
            this.Close(); // This doesnt close the form on the first time
        }
    }
