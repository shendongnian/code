       try
        {
            c.ExecuteNonQuery();
        }
        catch (SqliteException ex)
        {
           // at this point the values in the partNumber textbox haven't been cleared out
           showAlerts(ex);
        }
        finally 
        {
            // clear the textbox after the code in the try block 
            // and the code in the catch block have executed (IF it executed)
            partnumber.Text = "";
            partqty.Text = "";
            partnumber.RequestFocus();
        }
