    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                if (!dataGridView1.SelectedCells.Contains(dataGridView1.Rows[i].Cells["cLoadName"]))
                {
                    float nextNumber = 0;
                    float sumNumbers = 0;
    
                        if (float.TryParse(dataGridView1.SelectedCells[i].FormattedValue.ToString(), out nextNumber))
                            sumNumbers += nextNumber;
    
    
                    tsslSumSelected.Text = "ჯამი: " + sumNumbers;
                    tsslTotalSelected.Text = "მონიშნული: " + dataGridView1.SelectedCells.Count.ToString();
                }
                else
                {
    
                }
            }    
    
        }
