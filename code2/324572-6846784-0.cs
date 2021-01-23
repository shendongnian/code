    private void btnPrintInvoice_Click(object sender, RoutedEventArgs e)
    {
            //This is Class where my List _RoomNumber is 
            DataToExcel.Invoice inv = new DataToExcel.Invoice();
            foreach (CheckInData coll in CheckInCollection)
            {                
                inv._RoomNumber.Add(coll.RoomNumber.ToString());                
            }
    }
