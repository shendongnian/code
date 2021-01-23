    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		this.InitializeComponent();
    
    		// Subscribe to the opening event.
    		// Example only: You should subscribe to the event in the designer.
    		_contextMenu.Opening += new CancelEventHandler(OnContextMenuOpening);
    	}
    
    	private void OnContextMenuOpening(object sender, CancelEventArgs e)
    	{			
    		// Create a menu item.
    		var item = new ToolStripMenuItem(DateTime.Now.ToString());
    		item.Click += new EventHandler(OnItemClick);
    
    		// Clear the content menu and add the item to it.
    		_contextMenu.Items.Clear();
    		_contextMenu.Items.Add(item);
    	}
    
    	private void OnItemClick(object sender, EventArgs e)
    	{
    		// Show the text of the item just for fun.
    		MessageBox.Show(((ToolStripMenuItem)sender).Text);
    	}
    }
