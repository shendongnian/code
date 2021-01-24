    private JsonReport _lastItemTag;
    
    public Form1()
    {
        InitializeComponent();
    }
    
    private void ReportTemplateManager_Load(object sender, EventArgs e)
    {
        // Initialize context menu for template control
        ContextMenu cm = new ContextMenu();
        //The event handler will be called when this menu item is clicked.
        cm.MenuItems.Add("Load", new EventHandler(LoadReport_Click));
        template_listview.ContextMenu = cm;
    }
    
    private void LoadReport_Click(object sender, EventArgs e)
    {
        //The 'sender' argument is the menu item that was clicked
        //In this case, it is the Load menu item so cast the sender
        var menuItem = sender as MenuItem;
        //Now get the Tag property and cast it to JsonReport
        _lastItemTag = menuItem.Tag as JsonReport;
        
        if (_lastItemTag != null)
        {
            Console.WriteLine("Loading"); // This get executed
            this.Close(); // This doesnt close the form on the first time
        }
    }
