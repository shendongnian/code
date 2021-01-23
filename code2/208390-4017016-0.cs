    public partial class Options : Form
    {
        //usercontrols
        Connections _connections;
        Notifications _notifications;
        Proxy _proxy;
    private void Options_Load(object sender, EventArgs e)
    {
        treeViewOptions.ExpandAll();
        _connections = new Connections();
        _notifications = new Notifications();
        _proxy = new Proxy();
    }
    private void treeViewOptions_AfterSelect(object sender, TreeViewEventArgs e)
    {
        ControlPanel.Controls.Clear();
        switch (treeViewOptions.SelectedNode.Name)
        {
            case "NodeConnection":
               
                ControlPanel.Controls.Add(_connections);
                break;
            case "NodeNotifications":
               
                ControlPanel.Controls.Add(_notifications);
                break;
            case "NodeProxy":
                
                ControlPanel.Controls.Add(_proxy);
                break;
        }
    }
       private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _connections.Dispose();          
            _notifications.Dispose();
            _proxy.Dispose();
        }
}
