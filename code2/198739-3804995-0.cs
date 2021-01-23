      //This is inside you code
                DataGridViewRow oldRow = dgv.Rows.Add(itemArray(dgv.Rows[2]));
    
    
                dgv.Rows.Remove(oldRow);
    
            }
    
            object[] itemArray(DataGridViewRow Row) 
            {
                int a = Row.DataGridView.ColumnCount - 1;
                object[] mOut = new object[a];
    
                for (int x = 0;x <= a ; x++)
                {
                    mOut[x] = Row.Cells[x].Value;
                }
                return mOut;
    
            }
