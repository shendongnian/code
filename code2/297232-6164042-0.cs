    //form1
        public partial class Form1 : Form
        {
            DataTable table;
            public Form1()
            {
                InitializeComponent();
                table = new DataTable("myTable");
                table.Columns.Add("column 1", typeof(string));
    
                //some example data:
                table.Rows.Add("a");
                table.Rows.Add("b");
                table.Rows.Add("c");
                dataGridView1.DataSource = table;
    
                dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            }
    
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                string _value = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (_value != String.Empty)
                {
                    using (Form2 f2 = new Form2(_value))
                    {
                        if (f2.ShowDialog() == DialogResult.OK)
                        { 
                        
                        }
                    }
                }
            }
        }
    
    //form2:
        public partial class Form2 : Form
        {
            public Form2(string value)
            {
                InitializeComponent();
                //some example data in the comboBox:
                comboBox1.Items.AddRange(new string[] { "a", "b", "c" });
    
                //lets select the item which came from form1:
                comboBox1.SelectedItem = value;
            }
        }
