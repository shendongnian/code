    private void Form14_Load(object sender, EventArgs e)
    {
        // You previus code here ...
        // Here is you new modify code:
        using (var dataSet = new DataSet())
        {
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            for(int colidx=0; colidx<=9; colidx++) // You have index from 0 to 9
            {
                // if you use C# 7 you use: 
                // dataGridView1.Columns[colidx].HeaderText = $"Old File {(colidx+ 1).ToString()};
                dataGridView1.Columns[colidx].HeaderText = "Old File " + (colidx+ 1).ToString();
                // The magic:
                for(int rowidx = 0; rowidx < dataGridView1.Rows.Count; rowidx++)
                {
                    string filepathcell = dataGridView1.Rows[rowidx].Cells[colidx].Value.ToString();
                    // Only filename, remember: implements "using System.IO;" and this may launch exception, be careful
                    dataGridView1.Rows[rowidx].Cells[colidx].Value = Path.GetFileName(filepathcell);
                    // Save full pathfile:
                    dataGridView1.Rows[rowidx].Cells[colidx].Tag = filepathcell;
                }
            }
        }
    }
