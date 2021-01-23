    Dictionary d = new Dictionary<string,bool>();
    int ColumnIndex = dgUretimListesi.CurrentCell.ColumnIndex;
    CmbAra.Text = "";
    for (int i = 0; i < dgUretimListesi.Rows.Count; i++)
    {
       d[dgUretimListesi.Rows.Cells[ColumnIndex].Value.ToString()] = true;
    }
    CmbAra.Items.AddRange(d.Keys);
