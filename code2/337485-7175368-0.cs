    public void Lista()
    {
        string[] col2 = new string[dataGridView1.Rows.Count];
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
 
                if (col2[i] == "Browse From File...")
                {
                    DialogResult result2 = openFileDialog2.ShowDialog();
                    if (result2 == DialogResult.OK)
                    {
                       // filename = openFileDialog1.FileName;
                    }
                }
    }
