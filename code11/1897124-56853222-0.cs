using System;
using System.Data;
using System.Drawing;
using System.Linq;
class Program
{
    private static void Main()
    {
        var table = new DataTable();
        table.Columns.Add(new DataColumn("Name", typeof(string)));
        table.Columns.Add(new DataColumn("Color", typeof(Color)));
        table.Rows.Add("First", Color.Red);
        table.Rows.Add("Second", Color.DarkRed);
        table.Rows.Add("Third", Color.Green);
        table.Rows.Add("Fourth", Color.Red);
        table.Rows.Add("Fifth", Color.Yellow);
        var filterColor = Color.Red;
        var queried = table.Select($"CONVERT(Color, System.String) = '{filterColor}'");
        //First, Fourth
        Console.WriteLine(string.Join(",", queried.Select(r => r["Name"])));
        Console.Read();
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable.select?view=netframework-4.8#System_Data_DataTable_Select_System_String_
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.data.datacolumn.expression?view=netframework-4.8
