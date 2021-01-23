    public static void RefreshListBox(ListBox listbox)             
    {                 
          SqlCeConnection connection = null;
          try
          {
               listbox.Items.Clear()    //I assume you may want to refresh?
               connection = new SqlCeConnection("Datasource = "C:\\Kontakty.sdf");
               connection.Open();                     
               SqlCeCommand command = new SqlCeCommand("SELECT * FROM Contacts", connection);
               SqlCeDataReader reader = command.ExecuteReader(); 
               while (reader.Read())   
               {
                   listbox.Items.Add(reader.GetString(0) + " " + reader.GetString(1));
               }
          }
          catch(Exception exc)
          {                         
              MessageBox.Show(exc.Message);                  
          }
    } 
