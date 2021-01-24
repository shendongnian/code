csharp 
OLVa.RowFormatter = (o) =>
{
	if(o.RowObject == "B")
		o.BackColor = Color.Pink;
};
**Reproducing Your Problem**
I was able to reproduce the problem you describe using the following (bad) code.  It creates a flicker like you describe:
csharp 
public class MainForm : Form
{
	public MainForm()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		// 
		// MainForm
		// 
		this.ClientSize = new System.Drawing.Size(284, 261);
		this.Name = "MainForm";
		this.ResumeLayout(false);
		this.PerformLayout();
		
		var OLVa = new ObjectListView();
		OLVa.Dock = DockStyle.Fill;
		OLVa.Columns.Add(new OLVColumn("Name", "ToString"));
		this.Controls.Add(OLVa);
		OLVa.AddObject("A");
		OLVa.AddObject("B");
		OLVa.AddObject("C");
		Timer t = new Timer();
		t.Interval = 100;
		t.Tick += (s,e)=>OLVa.RefreshObject("B");
		t.Start();
		Timer t2 = new Timer();
		t2.Interval = 200;
		t2.Tick += (s,e)=>OLVa.GetItem(1).BackColor = Color.Pink;
		t2.Start();
	}
}
Changing the second timer to the row formatter fixed the problem.
**Changing Row Highlighting Based On Condition**
Calling `RefreshObject` automatically triggers `RowFormatter` and aspects so if you want to change the state of a row over time (e.g. as you requested in comment) you could do something like this:
csharp
    public class MainForm : Form
    {
        public MainForm()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();
            var OLVa = new FastObjectListView();
            OLVa.Width = 250;
            OLVa.Height = 250;
            OLVa.Columns.Add(new OLVColumn("Done", "Done"));
            OLVa.Columns.Add(new OLVColumn("Percent", "PercentComplete"));
            
            this.Controls.Add(OLVa);
            Video v = new Video();
            OLVa.AddObject(v);
            var t = new Timer();
            t.Interval = 1000;
            t.Start();
            OLVa.RowFormatter = (s) => s.BackColor = ((Video) s.RowObject).Done ? Color.Green : Color.Red;
            t.Tick += (s,e)=>
            {
                v.PercentComplete = Math.Min(v.PercentComplete += 10, 100);
                if (v.PercentComplete == 100)
                    v.Done = true;
                OLVa.RefreshObject(v);
            };
        }
        private class Video
        {
            public bool Done { get; set; }
            public int PercentComplete { get; set; }
        }
    }
