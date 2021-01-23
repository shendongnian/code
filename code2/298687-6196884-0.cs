    private void ToCsV(DataGridView dGV, string filename)
    
        {
        
        string stOutput = "";
        
        // Export titles:
        
        string sHeaders = "";
        
        for (int j = 0; j < dGV.Columns.Count; j++)
        
        sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
        
        stOutput += sHeaders + "\r\n";
        
        // Export data.
        
        for (int i = 0; i < dGV.RowCount - 1; i++)
        
        {
        
        string stLine = "";
        
        for (int j = 0; j < dGV.Rows.Cells.Count; j++)
        
        stLine = stLine.ToString() + Convert.ToString(dGV.Rows.Cells[j].Value) + "\t";
        
        stOutput += stLine + "\r\n";
        
        }
        
        Encoding utf16 = Encoding.GetEncoding(1254);
        
        byte[] output = utf16.GetBytes(stOutput);
        
        FileStream fs = new FileStream(filename, FileMode.Create);
        
        BinaryWriter bw = new BinaryWriter(fs);
        
        bw.Write(output, 0, output.Length); //write the encoded file
        
        bw.Flush();
        
        bw.Close();
        
        fs.Close();
        
        }
         
        
        private void button2_Click(object sender, EventArgs e)
        
        {
        
        SaveFileDialog sfd = new SaveFileDialog();
        
        sfd.Filter = "Text Documents (*.txt)|*.txt";
        
        sfd.FileName = "export.txt";
        
        if (sfd.ShowDialog() == DialogResult.OK)
        
        {
        
        //ToCsV(dataGridView1, @"c:\export.xls");
        
        ToCsV(dataGridView1, sfd.FileName);
        
        }
