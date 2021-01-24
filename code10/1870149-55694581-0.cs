    string[] productName = new string[GridView1.Rows.Count];
                
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
        var row = GridView1.Rows[i];
        productName[i] = row.Cells[1].Text;
                    
    }
