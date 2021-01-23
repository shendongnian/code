    using (SqlConnection cnn = new SqlConnection("YourCnnString"))
    {
    
         try
         {
                cnn.Open();
         }
         catch (InvalidOperationException)
         {
                 SqlConnection.ClearPool(cnn);
         }
         cnn.Open();
         
    }
