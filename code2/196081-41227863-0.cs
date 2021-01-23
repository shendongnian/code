    int numRows = dgbDatos.Rows.Count;    
    for (int i = 0; i < numRows; i++)
    {
        try
        {    
            int max = dgbDatos.Rows.Count - 1;
            dgbDatos.Rows.Remove(dgbDatos.Rows[max]);
            btnAgregar.Enabled = true;
        }
        catch (Exception exe)
        {
            MessageBox.Show("No se puede eliminar " + exe, "",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
