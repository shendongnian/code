    public Form1()
            {
    
                InitializeComponent();
                //This can be removed before utilizing
                     dgv.Rows.Add("1", "1", "1");
                     dgv.Rows.Add("1", "1", "1");
                     dgv.Rows.Add("bob", "bob", "bob");
                     dgv.Rows.Add("1", "1", "1");
                     dgv.Rows.Add("1", "1", "1");
                     dgv.Rows.Add("1", "1", "1");
                //This can be removed before utilizing
    
    
                int oldrow = 2;
    
                dgv.Rows.Add(itemArray(dgv.Rows[oldrow]));
                
                dgv.Rows.RemoveAt(oldrow);
                /*
                 DataGridViewRow oldRow = dataGridView1.Rows.Add(itemarray(dataGridView1.Rows[1])); dataGridView1.Rows.Remove(oldRow)
                 */
    
            }
    
            object[] itemArray(DataGridViewRow Row) 
            {
                int a = Row.DataGridView.ColumnCount - 1;
                object[] mOut = new object[a+1];
    
                for (int x = 0;x <= a ; x++)
                {
                    mOut[x] = Row.Cells[x].Value;
                }
                return mOut;
    
            }
