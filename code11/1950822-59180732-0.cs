       string defTable = "";
       if( GPBox.IsChecked )
          defTable = "gpSurgery";
       else if (DentistBox.IsChecked == true)
          defTable = "Dentist";
       else if (SchoolsBox.IsChecked == true)
          defTable = "Schools";
       else if (NurseryBox.IsChecked == true)
          defTable = "Nursery";
       else if (OpticianBox.IsChecked == true)
          defTable = "Opticians";
       else
       {
          MessageBox.Show("Select a service.");
          return;
       }
       // valid choice...
       // this is NOT going to be an issue of SQL-Injection because YOU are 
       // controlling the string values for the table name to query from.
       connect = new MySqlConnection(connectionString);
       cmd = new MySqlCommand("select distinct nameOfService, street, city, postcode, contactNumber from " + defTable, connect);
       MySqlDataAdapter sqlDA = new MySqlDataAdapter();
       YourData = new DataTable();
       YourData.Load(cmd.ExecuteReader());
       connect.Close();
