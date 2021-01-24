var col = new DataGridTextColumn ();
...
dgItemDisplay.Columns.Add (col3);
B. Write a field variable such as bool isColumnAdded = false; in the class.And change inside "txtItemCode_KeyDown" as follows.
if (!isColumnAdded)
{
    isColumnAdded = true;
    var col = new DataGridTextColumn ();
    ...
    dgItemDisplay.Columns.Add (col3);
}
The DataGrid.Columns.Add method is a method to increase the column of the DataGrid on the UI.
Once the ItemCode, ItemName, ItemPrice columns are displayed, the columns will remain visible.
(I'm sorry if you understood it already.)
