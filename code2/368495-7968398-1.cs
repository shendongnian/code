    public class Form1
    {
	    private Panel CreateNotificationPanel()
	    {
		    var p = new Panel { BackColor = Color.Red };
		    p.Controls.Add(new Button { Text = "Test" });
		    return p;
	    }
	    private void Form1_Load(System.Object sender, System.EventArgs e)
	    {
		    var flp = new FlowLayoutPanel { Dock = DockStyle.Fill };
		    flp.Controls.Add(CreateNotificationPanel());
		    flp.Controls.Add(CreateNotificationPanel());
		    flp.Controls.Add(CreateNotificationPanel());
		    this.Controls.Add(flp);
	    }
        public Form1() { Load += Form1_Load; }
    }
