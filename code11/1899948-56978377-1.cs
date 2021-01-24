lang-csharp
var dataTable = new DataTable();
dataTable.Columns.Add("ColumnName", typeof(int));
This will cause the bound `DataGridView` to sort that column as integers.
It looks like there is a `DataType` in the Columns Collection Editor as well, if you're using the designer to create your `DataSet`. You can set the type to `System.Int32` on that column and it will sort as you expect.
lang-csharp
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         var frm = new Form()
         {
            Text = "Data Grid View Form",
            Name = "DataGridViewForm",
            Size = new System.Drawing.Size(400, 400)
         };
         var dataGridView1 = new DataGridView();
         var dataTable = new DataTable();
         dataGridView1.DataSource = dataTable;
         dataGridView1.Dock = DockStyle.Fill;
         dataTable.Columns.Add("Id", typeof(int));
         dataTable.Columns.Add("IdAsString", typeof(string));
         var r1 = dataTable.NewRow();
         r1["Id"] = 1;
         r1["IdAsString"] = "1";
         dataTable.Rows.Add(r1);
         var r2 = dataTable.NewRow();
         r2["Id"] = 11;
         r2["IdAsString"] = "11";
         dataTable.Rows.Add(r2);
         var r3 = dataTable.NewRow();
         r3["Id"] = 2;
         r3["IdAsString"] = "2";
         dataTable.Rows.Add(r3);
         var r4 = dataTable.NewRow();
         r4["Id"] = 22;
         r4["IdAsString"] = "22";
         dataTable.Rows.Add(r4);
         frm.Controls.Add(dataGridView1);
         Application.Run(frm);
      }
   }
}
