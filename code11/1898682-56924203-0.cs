using System.Data;
using System.Windows.Forms;
namespace testApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.dataGridView1.AutoGenerateColumns = true;
			var dt = new DataTable();
			this.dataGridView1.DataSource = dt;
			dt.Columns.Add(new DataColumn("Id"));
			dt.Columns.Add(new DataColumn("Name"));
		}
	}
}
The above example is a basic stuff to get you started. You can do everything at run-time what you think you're able to do with form designer. Just go through the form's designer.cs file and see the logic behind the magic of VS form designer
