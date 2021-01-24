`
using System;
using System.Windows.Forms;
namespace WindowsFormsAppTest
{
  public partial class FormTest : Form
  {
    public FormTest()
    {
      InitializeComponent();
    }
`
`
    private void FormTest_Load(object sender, EventArgs e)
    {
      listBox1.Items.Add(new CartItem { ID = 1, Name = "Item 1", Quantity = 10 });
      listBox1.Items.Add(new CartItem { ID = 2, Name = "Item 2", Quantity = 20 });
      listBox1.Items.Add(new CartItem { ID = 3, Name = "Item 3", Quantity = 30 });
      listBox1.Items.Add(new CartItem { ID = 4, Name = "Item 4", Quantity = 40 });
      dataGridView2.Columns.Add("ID", "ID");
      dataGridView2.Columns.Add("Name", "Name");
      dataGridView2.Columns.Add("Quantity", "Quantity");
    }
`
`
    private void ActionAddToCart_Click(object sender, EventArgs e)
    {
      dataGridView2.AutoGenerateColumns = false;
      if ( listBox1.SelectedItem != null )
        foreach ( CartItem item in listBox1.SelectedItems )
        {
          int index = dataGridView2.Rows.Add();
          dataGridView2.Rows[index].Cells["ID"].Value = item.ID;
          dataGridView2.Rows[index].Cells["Name"].Value = item.Name;
          dataGridView2.Rows[index].Cells["Quantity"].Value = item.Quantity;
        }
    }
`
`
    private void ActionClearCart_Click(object sender, EventArgs e)
    {
      dataGridView2.Rows.Clear();
    }
`
`
  }
`
`
  public class CartItem
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public override string ToString()
    {
      return Name;
    }
  }
`
`
}
`
