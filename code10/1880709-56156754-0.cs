<asp:Table runat="server" ID="myTable"></asp:Table>
In your code-behind file:
using System.Web.UI.WebControls;
...
void SomeMethod()
{
    var row = new TableRow();
    var cell = new TableCell();
    var radioButtonList = new RadioButtonList();
    radioButtonList.Items.Add(new ListItem("Yes"));
    radioButtonList.Items.Add(new ListItem("NO"));
    cell.Controls.Add(radioButtonList);
    row.Cells.Add(cell);
    myTable.Rows.Add(row);
}
