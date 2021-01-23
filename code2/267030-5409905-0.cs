    public partial class Form1 : Form
        {
            BindingList<Person> bList;
            public Form1()
            {
                InitializeComponent();
                bList = new BindingList<Person> 
                {
                    new Person{ id=1,name="John"},
                    new Person{id=2,name="Sara"},
                   new Person{id=3,name="Goerge"}
                };
                dataGridView1.DataSource = bList;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string item = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                if (item != null && dataGridView1.CurrentCell.ColumnIndex != 0)
                {
                    int _id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
                    var bList_Temp = bList.Where(w => w.id == _id).ToList();
    
                    //REMOVE WHOLE ROW:
                    foreach (Person p in bList_Temp)
                        bList.Remove(p);
                }
            }
        }
    
        class Person
        {
            public int id { get; set; }
            public string name { get; set; }
        }
