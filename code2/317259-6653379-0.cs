    private static readonly createIcon cIcon = new createIcon();
    private NotifyIcon notify;
    private ContextMenuStrip contextMenu = new ContextMenuStrip();
    private bool IsDisposing = false;
    
    public static createIcon getIconObject()
    {
          return cIcon;
    }
    
    private createIcon()
    {
                ToolStripMenuItem ssItem = new ToolStripMenuItem("Open", null, new EventHandler(notify_DoubleClick));
                contextMenu.Items.Add(ssItem);
                ssItem = new ToolStripMenuItem("Settings",null, new EventHandler(settings_Click));
                contextMenu.Items.Add(ssItem);
                ssItem = new ToolStripMenuItem("About", null, new EventHandler(about_Click));
                contextMenu.Items.Add(ssItem);
                ssItem = new ToolStripMenuItem("Exit", null, new EventHandler(Menu_OnExit));
                contextMenu.Items.Add(ssItem);
                
                notify = new NotifyIcon();
                notify.Icon = "Icon.ICO";
                notify.Text = "Name";
                notify.ContextMenuStrip = contextMenu;
                notify.DoubleClick += new EventHandler(notify_DoubleClick);
                notify.Visible = true;
    }
    
    public void Dispose()
    {
         if (!IsDisposing)
         {
             IsDisposing = true;
         }
    }
    
    private void notify_DoubleClick(object sender, EventArgs e)
    {
    	.... code here
    }
