        int ColumnIndex = dgUretimListesi.CurrentCell.ColumnIndex;
        CmbAra.Text = "";
        HashSet<string> set = new HashSet<string>();
        for (int i = 0; i < dgUretimListesi.Rows.Count; i++)
        {
            string s = dgUretimListesi.Rows.Cells[ColumnIndex].Value.ToString();
            if(!set.Contains(s)) {
                CmbAra.Items.Add(s);
                set.Add(s);
            }           
        }
