Assuming this is a PropertyGrid in winforms app. Then it's neither a string concatenation issue, nor PropertyGrid issue, as could be proven by the following snippet. So you need to look elsewhere in your code:
public partial class Form1 : Form {
	PropertyGrid pg;
	public Form1() {
		pg = new PropertyGrid();
		pg.Dock = DockStyle.Fill;
		this.Controls.Add(pg);
		var inputFile = "some fileName.txt";
		var obj = new Obj();
		obj.One = "Error_" + inputFile;
		obj.Two = inputFile + "Error_";
		pg.SelectedObject = obj;
	}
}
class Obj {
	public string One { get; set; }
	public string Two { get; set; }
}
