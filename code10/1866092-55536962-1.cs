    private void DGV_Total_Btn_Click(object sender, EventArgs e)
    {
        DGV3.Rows.Clear();
        int yourColumnIndex = 3;    // column index from "Ampl (dB)"
        double total = 0;           
        foreach(DataGridViewRow row in DGV1.Rows)
        {
            total = Convert.ToDouble(row.Cells[yourColumnIndex].Value) + Convert.ToDouble(DGV2.Rows[row.Index].Cells[yourColumnIndex].Value);
            DGV3.Rows.Add(new object[] { row.Cells[0].Value,    //copy List
                                         row.Cells[1].Value,    //copy Theta
                                         row.Cells[2].Value,    //copy Phi
                                         total });              //add total "Ampl (dB)"
        }
    }
