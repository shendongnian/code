    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindingList<Values> values = new BindingList<Values>();
            values .Add(new Values() { ValueOne = 1, ValueTwo = 2});
            values .Add(new Values() { ValueOne = 1, ValueTwo = 2});
            values .Add(new Values() { ValueOne = 1, ValueTwo = 2 });
            dataGridView1.DataSource = values ;          
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }
        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (e.ColumnIndex == dataGridView1.Columns["ValueOne"].Index)
            {
                DataGridViewCell neighbour = dataGridView1[e.ColumnIndex + 1, e.RowIndex];
                neighbour.Value = ((int)cell.Value) + ((int)neighbour.Value);
            }
        }
    }
    public class Values
    {
        public int ValueOne { get; set; }
        public int ValueTwo { get; set; }
    }
