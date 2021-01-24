    public partial class Form1 : Form
        {
            DataTable table = new DataTable();
            public Form1()
            {
                InitializeComponent();
                table.Columns.Add("Number", typeof(int));
                table.Columns.Add("Food", typeof(string));
                table.Columns.Add("FoodType", typeof(string));
    
                // add rows
                table.Rows.Add(1, "BBQ", "Meat");
                table.Rows.Add(2, "Pear","Fruit");
                table.Rows.Add(3, "Eggs", "Eggs");
                table.Rows.Add(4, "Banana", "Fruit");
                table.Rows.Add(5, "Noodle","Veg");
                table.Rows.Add(6, "Orange", "Fruit");
                table.Rows.Add(7, "Mango", "Fruit");
                table.Rows.Add(8, "Beef","Meat");
    
                dataGridView1.DataSource = table;
               //hide the foodtype column
                this.dataGridView1.Columns["FoodType"].Visible = false;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (textBox1.Text != "")
                {
                    DataView dv = new DataView(table, "FoodType= '" + textBox1.Text + "'", "FoodType Desc", DataViewRowState.CurrentRows);
    
                    dataGridView1.DataSource = dv;
                }
                else
                    dataGridView1.DataSource = table;
            }
        }
