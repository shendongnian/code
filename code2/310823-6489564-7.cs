    private void push_Click(object sender, EventArgs e)
    {    
        StringBuilder nominal = new StringBuilder();
        for(int i = 0;i<DGV.Rows.Count;i++){
            nominal.Append(Convert.ToString(DGV.Rows[i].Cells[1].Value) + ";");
        }
        WSBrand insertInto = new WSBrand();
        InsertInto.Insert(nominalList); 
    }
