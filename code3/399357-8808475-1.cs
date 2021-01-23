    public partial class Form1 : Form
    {    
        int[] w = new int[100];
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;    
            Shown += new EventHandler(Form1_Shown);
        }
    
        void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.ColumnWidthChanged += dataGridView1_ColumnWidthChanged;
    
            //to know what WERE the widths.
            for (int i = 0; i < dataGridView1.Columns.Count; i++) w[i] = dataGridView1.Columns[i].Width;
    
            //Won't work without this.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }    
    
        void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int column = e.Column.Index;
    
            //unsubscribe so changing will not call itself.
            dataGridView1.ColumnWidthChanged -= dataGridView1_ColumnWidthChanged;
    
            //updating width.
            dataGridView1.Columns[column + 1].Width = (w[column + 1] + w[column]) - dataGridView1.Columns[column].Width;
            w[column + 1] = dataGridView1.Columns[column + 1].Width;
            w[column] = dataGridView1.Columns[column].Width;
    
            //re-subscribe
            dataGridView1.ColumnWidthChanged += dataGridView1_ColumnWidthChanged;
        }    
    }
