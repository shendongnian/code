    public class MyDGV : DataGridView
	{
		this.VerticalScrollBar.Paint += new PaintEventHandler(VerticalScrollBar_Paint);
	}
	void VerticalScrollBar_Paint(object sender, PaintEventArgs e)
	{
		// Paint stuff
	}
