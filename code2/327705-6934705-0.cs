        foreach (DataGridViewRow Datarow in contentTable_grd.Rows)
        {
            if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null)
            {
                contentValue1 = Datarow.Cells[0].Value.ToString();
                contentValue2 = Datarow.Cells[1].Value.ToString();
                MessageBox.Show(contentValue1);
                MessageBox.Show(contentValue2);
            }
        }
