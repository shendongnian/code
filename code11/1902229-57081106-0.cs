    private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            if ((bool)DGVProductos.SelectedRows[e.ColumnIndex].Cells["CheckProducto"].Value == false)
            {
                DGVProductos.SelectedRows[e.ColumnIndex].Cells["CheckProducto"].Value = true;
            }
            else
            {
                DGVProductos.SelectedRows[e.ColumnIndex].Cells["CheckProducto"].Value = false;
            }
        }    
    }
