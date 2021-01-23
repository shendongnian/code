    void btnNext_Click(object sender, EventArgs e) {
        int id = Int32.Parse(yourIdTextBox.Text);
        
        DataRow row = ds1.Tables["Laptops"].Rows.OfType<DataRow>()
                         .SingleOrDefault(r => (int)r.ItemArray[your id index] == id);
        if (row == null)
        {
             //user typed in invalid row id
        }  else
              processRow(row);
    }
    void processRow(DataRow row){
        txtMaker.Text = row.ItemArray.GetValue(1).ToString();
        txtModel.Text = row.ItemArray.GetValue(2).ToString();
        txtPrice.Text = row.ItemArray.GetValue(3).ToString();
        txtBids.Text = row.ItemArray.GetValue(4).ToString();
        txtScreen.Text = row.ItemArray.GetValue(5).ToString();
        txtCPU.Text = row.ItemArray.GetValue(6).ToString();
        txtMemory.Text = row.ItemArray.GetValue(7).ToString();
        txtHD.Text = row.ItemArray.GetValue(8).ToString();
        picLaptops.Image = Image.FromFile(row.ItemArray.GetValue(9).ToString());
    }
