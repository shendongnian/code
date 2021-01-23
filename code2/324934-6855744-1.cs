    //at form load:
    dataGirdView1.KeyPress += OnDataGirdView1_KeyPress;
    private void OnDataGirdView1_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (e.KeyChar == (char)Keys.Enter)
         { 
             RunMyCustomCode(); 
         }
    }
 
