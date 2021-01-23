    private void grid_order_CellContentClick(
                     object sender, 
                     DataGridViewCellEventArgs e)
    {
        Textbox1.Text = Convert.ToString( Gridview.SelectedCells[0].Value);      
    }
