    private void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            /* ... */
    
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredRows.CopyToDataTable();
        }
        catch (Exception ex)
        {
            /* ... */
        }
    }
