c#
public class MyDataGridViewTextBoxColumn : DataGridViewTextBoxColumn
{
    public MyDataGridViewTextBoxColumn() =>
        CellTemplate = new MyDataGridViewTextBoxCell();
}
And your `Cell` class should be like:
c#
public class MyDataGridViewTextBoxCell : DataGridViewTextBoxCell
{
    public MyDataGridViewTextBoxCell() { }
    public string Url { get; set; }
    
    //Don't forget to clone your new properties.
    public override object Clone()
    {
        var c = base.Clone();
        ((MyDataGridViewTextBoxCell)c).Url = Url;
        return c;
    }
}
To implement that:
c#
var myNewTBC = new MyDataGridViewTextBoxColumn
{
    HeaderText = "My Custom TB",
};
dataGridView1.Columns.Add(myNewTBC);
Assuming that the custom text box column is the first column in the DGV:
c#
var myTB = (MyDataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[0];
myTB.Url = "...";
