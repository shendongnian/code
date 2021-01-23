    private void Form1_Load(object sender, EventArgs e)
       {
           DataTable dt = new DataTable();
           dt.Columns.Add("c1", typeof(int));
           dt.Columns.Add("c2");
           for (int j = 0; j < 10; j++)
           {
               dt.Rows.Add(j, "aaa" + j.ToString());
           }
           this.dataGridView1.DataSource = dt;
           this.dataGridView1.EditingControlShowing +=
               new DataGridViewEditingControlShowingEventHandler(
                   dataGridView1_EditingControlShowing);
       }
       private bool IsHandleAdded;
       void dataGridView1_EditingControlShowing(object sender,
           DataGridViewEditingControlShowingEventArgs e)
       {
           if (!IsHandleAdded &&
                 this.dataGridView1.CurrentCell.ColumnIndex == 0)
           {
               TextBox tx = e.Control as TextBox;
               if (tx != null)
               {
                   tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                   this.IsHandleAdded = true;
               }
           }
       }
       void tx_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
           {
               e.Handled = true;
           }
       }
