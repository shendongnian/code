    int numRows = dgbDatos.Rows.Count;    
    for (int i = 0; i < numRows; i++)
    {
        try
        {    
            int max = dgbDatos.Rows.Count - 1;
            dgbDatos.Rows.Remove(dgbDatos.Rows[max]);
            
        }
        catch (Exception exe)
        {
            MessageBox.Show("You can´t delete A row " + exe, "WTF",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
