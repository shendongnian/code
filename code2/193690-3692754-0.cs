     public void setABCColor(DataGridView DGV)
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if ((string)DGV.Rows[i].Cells[6].Value == "A")
                {
                    DGV.Rows[i].Cells[6].Style.BackColor = Color.Green;
                }
                else if ((string)DGV.Rows[i].Cells[6].Value == "B")
                {
                    DGV.Rows[i].Cells[6].Style.BackColor = Color.Blue;
                }
                else
                {
                    DGV.Rows[i].Cells[6].Style.BackColor = Color.Red;
                }
            }
        }
