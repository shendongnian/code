    public Form1()
     { 
          dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(populateTextBox());
          dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(populateTextBox());
          dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(populateTextBox());
          dataGridView4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(populateTextBox());
     }
    private void populateTextBox(object sender, DataGridViewCellEventArgs e)
    {
        //code here
        //You can use e.Value (cell value data type dependant) if required
    }
