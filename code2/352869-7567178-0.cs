    if(!(CmbAra.Items.Contains(dgUretimListesi.Rows.Cells[ColumnIndex].Value.ToString())))
    {
       CmbAra.Items.Add(dgUretimListesi.Rows.Cells[ColumnIndex].Value.ToString());
    }
    else
    {
       MessageBox.Show("Value Already exists , not added");
    }
