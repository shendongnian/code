    private void grdDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Sólo queremos esta funcionalidad para determinadas columnas Clave y Nombre
            if ((grdDetalle.Columns[grdDetalle.CurrentCell.ColumnIndex].Name == "colClaveArticulo") ||
                (grdDetalle.Columns[grdDetalle.CurrentCell.ColumnIndex].Name == "colNombre"))
            {
                /// Workarround para que estando editando en las columnas del grid Clave y Nombre
                /// podamos detectar cuando se dio F4 para lanzar el dialogo de busqueda del
                /// articulo.
                e.Control.KeyDown += new KeyEventHandler(dataGridViewTextBox_KeyDown);
                e.Control.Leave += new EventHandler(dataGridViewTextBox_Leave);
            }
        }
        private void dataGridViewTextBox_Leave(object sender, EventArgs e)
        {
            
            if ((grdDetalle.Columns[grdDetalle.CurrentCell.ColumnIndex].Name == "colClaveArticulo") ||
               (grdDetalle.Columns[grdDetalle.CurrentCell.ColumnIndex].Name == "colNombre"))
            {
                try
                {
                    (sender as DataGridViewTextBoxEditingControl).KeyDown -= 
                       new KeyEventHandler(dataGridViewTextBox_KeyDown);
                }
                catch (Exception ex)
                { }
            }
        }
        private void dataGridViewTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // F4 Pressed
            if ((grdDetalle.Columns[grdDetalle.CurrentCell.ColumnIndex].Name == "colClaveArticulo") ||
               (grdDetalle.Columns[grdDetalle.CurrentCell.ColumnIndex].Name == "colNombre"))
            {
                if (e.KeyCode == Keys.F4) // 115
                {
                    MessageBox.Show("Oprimieron F4");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
