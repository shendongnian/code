    private double DGVTotal()
        {
            double tot = 0;
            int i = 0;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
    			Double dbTemp = Convert.ToDouble(dataGridView1.Rows[i].Cells["Total"].Value);
    			if (dbTemp > 0)
    			   tot = tot + dbTemp;
            }
            return tot;
        }
