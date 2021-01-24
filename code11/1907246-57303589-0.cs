       //This is my connection string i have assigned the database file address path  
       string MyConnection2 = 
       "host='localhost';database='databasename';username='myusername';password='mypassword'";
       //This is my insert query in which i am taking input from the user through windows forms  
       string Query = "Your query";
       //This is  MySqlConnection here i have created the object and pass my connection string.  
       MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
       //This is command class which will handle the query and connection object.  
       MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
       MySqlDataReader MyReader2;
       MyConn2.Open();
       MyReader2 = MyCommand2.ExecuteReader();     
       // Here our query will be executed and data saved into the database.  
       MessageBox.Show("Save Data");
       while (MyReader2.Read())
       {
       }
       MyConn2.Close();
