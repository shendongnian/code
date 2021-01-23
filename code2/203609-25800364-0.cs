       private void gvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (dataGridView2.CurrentCell != null && dataGridView2.CurrentCell.Value != null)
             {
               txtDescripcion.Text = string.Empty;
               textBox1.Text = dataGridView2.CurrentCell.Value.ToString();
            }  
        }
