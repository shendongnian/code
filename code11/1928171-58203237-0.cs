    private void M_MortagagePaymentGrid_ColumnHeaderClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
    {
        if (e.Column.Index == 4)// this column: dateDescription 
        {
            e.Column.Index = 3; //use the column index for the date column
        }
        //Call the base Event handler here with (sender, e)
       
    }
