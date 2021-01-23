    public Form1()
    {
       InitializeComponent();
       dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
    }
    HashSet<int> column_indicies = new HashSet<int>();
    HashSet<string> column_names = new HashSet<string>();
    int number_of_columns = 0;
    
    void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
       column_indicies.Clear();
       column_names.Clear();
       foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
       {
          // Set of column indicies
          column_indicies.Add(cell.ColumnIndex);
          // Set of column names
          column_names.Add(dataGridView1.Columns[cell.ColumnIndex].Name);
       }
       // Number of columns the selection ranges over
       number_of_columns = column_indicies.Count;
    }
