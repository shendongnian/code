    public partial class MainWindow : Form
    {
    	public int getSelectedTabIndex()
    	{
    		if (tabControl1.InvokeRequired)
    			return (int)tabControl1.Invoke(new Func<int>(getSelectedTabIndex));
    		else
    			return tabControl1.SelectedIndex;
    	}
    }
