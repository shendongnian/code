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
