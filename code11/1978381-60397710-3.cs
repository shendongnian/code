    private void button1_Click(object sender, EventArgs e)
    {
        if (this.dataGridView1.CurrentCell != null)
        {
            Cursor.Current = Cursors.WaitCursor;
    
            // This is the only line modified
            string file = dataGridView1.CurrentCell.Tag.ToString();
            Cursor.Current = Cursors.Default;
    
            if (File.Exists(file))
            {
                Cursor.Current = Cursors.WaitCursor;
                Process.Start("explorer.exe", " /select, " + file);
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("No File Found...");
            }
    
        }
        else
        {
            MessageBox.Show("No record selected");
        }
    }
