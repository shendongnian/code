     private void push_Click(object sender, EventArgs e)
    {    
        List<string> nominalList = new List<string>();
        for(int i = 0;i<DGV.Rows.Count;i++){
            nominalList.Add(Convert.ToString(DGV.Rows[i].Cells[1].Value));
        }
        WSBrand insertInto = new WSBrand();
        InsertInto.Insert(nominalList); 
    }
