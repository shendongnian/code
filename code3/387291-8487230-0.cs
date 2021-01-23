    public class GraphOneWindow:Form
    {
       public GraphOneWindow(object sender)
       {
           InitializeComponent();
           //cast and use sender here
       }
    }
    private void menuItemTemp_Click(object sender, EventArgs e)
    {
       (new GraphOneWindow(sender)).Show();
    }
