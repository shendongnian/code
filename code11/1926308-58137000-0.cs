C#
public partial class Ribbon1
{
private void FL_Click(object sender, RibbonControlEventArgs e)
   {
       Sis2D s = Globals.Sis2D;
       s.LlenaListBox();   
   }
}
In the sheet, the code is:
public partial class Sis2D 
{
public void LlenaListBox()
    {
            Excel.Worksheet wsFL = Globals.ThisWorkbook.Worksheets["Sheet1"];
            ListaF.Items.Add(wsFL.Range["A10"].Value);
            ListaF.Items.Add(wsFL.Range["A11"].Value);
            ListaF.Items.Add(wsFL.Range["A12"].Value);
    }
}
This is all. ListaF is a ListBox added to sheet1 into a worksheet from C# in Visual Studio.
The following picture shows how the worksheet looks:
[enter image description here][1]
  [1]: https://i.stack.imgur.com/ztmrX.png
