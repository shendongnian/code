//we'll need to process this table
var table = DATASET_DATA.Tables[0];
//First, add a column for BackColor and calculate values
//Here I use a simple column of type Color and default order (alphabetically, by color name)
//If you need a more complicated sorting, consider creating a numeric (BackColorOrder) column instead
table.Columns.Add("BackColor", typeof(Color));
foreach (DataRow row in table.Rows)
{
    string BEFORE_HYPHEN = GetUntilOrEmpty(Convert.ToString(row[2]));
    if (BEFORE_HYPHEN.Length == 2)
    {
        //white, or whatever your default color is
        row["BackColor"] = Color.White;
    }
    else
    {
        row["BackColor"] = Color.Yellow;
    }
}
//Assign a sorted binding source as a datasource
var bs = new BindingSource
{
    DataSource = table,
    Sort = "BackColor ASC"
};
dataGridView1.DataSource = bs;
//Hide backcolor from the grid
//If this column has a meaning in your application (some kind of a status?)
//Consider displaying it, so the user will be able to change sort order
dataGridView1.Columns["BackColor"].Visible = false;
...
/// <summary>
/// We're using DataBindingComplete to calculate color for all rows
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
{
     //Assign a pre-calculated BackColor for grid rows
     foreach (DataGridViewRow row in dataGridView1.Rows)
     {
          row.DefaultCellStyle.BackColor = (Color)row.Cells["BackColor"].Value;
     }
}
Here's a [full, runnable example][4]. The result looks like this:
[![enter image description here][5]][5]
Sorting a non-databound DataGridView
--
If your datagridview is *not* data-bound, you should be able to sort it using [`Sort(IComparer comparer)`][6]: 
dataGridView1.Sort(new BackColorComparer());
...
/// <summary>
/// Custom comparer will sort rows by backcolor
/// </summary>
private class BackColorComparer : System.Collections.IComparer
{
     public int Compare(object x, object y)
     {
          var row1 = (DataGridViewRow)x;
          var row2 = (DataGridViewRow)y;
          //Sorting by color names, replace with custom logic, if necessary
          return string.Compare(
               row1.DefaultCellStyle.BackColor.ToString(),
               row2.DefaultCellStyle.BackColor.ToString());
     }
}
Make sure to run this code only after you finished calculating `BackColor` for all the rows.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.cellformatting?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.databindingcomplete?view=netframework-4.8
  [3]: https://stackoverflow.com/users/3152130/taw
  [4]: https://gist.github.com/defaultlocale/188ea4fff140d10173dc5b0e2e17f71b
  [5]: https://i.stack.imgur.com/Q0fHh.png
  [6]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.sort?view=netframework-4.8#System_Windows_Forms_DataGridView_Sort_System_Collections_IComparer_
