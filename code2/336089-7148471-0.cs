    using System;
    using System.Windows.Forms;
    
    public class LVTest : Form {
    	public LVTest() {
    		ListView lv = new ListView();
    		lv.Columns.Add("Header", 100);
    		lv.Columns.Add("Details", 100);
    		lv.Dock = DockStyle.Fill;
    		lv.Items.Add(new ListViewItem(new string[] { "Alpha", "Some details" }));
    		lv.Items.Add(new ListViewItem(new string[] { "Bravo", "More details" }));
    		lv.View = View.Details;
    		Controls.Add(lv);
    	}
    }
    
    public static class Program {
    	[STAThread] public static void Main() {
    		Application.Run(new LVTest());
    	}
    }
