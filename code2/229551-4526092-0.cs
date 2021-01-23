       try          
            {      
                //Create a OLEDB connection for Excel file    
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +  
                    "Data Source=" + "d:\\data.xls" + ";" +  
                    "Extended Properties=Excel 8.0;";   
                OleDbConnection objConn = new OleDbConnection(connectionString); 
                objConn.Open();               
                // Creating a command object to read the values from Excel file   
                OleDbCommand ObjCommand = new OleDbCommand("SELECT DocumentNo FROM [Sheet1$]", objConn);  
                // Creating a Read object             
                OleDbDataReader objReader = ObjCommand.ExecuteReader();  
                
                // Looping through the values and displaying   
                
                //if (objReader.
                
                while (objReader.Read())       
                {
                    object obj = objReader["DocumentNo"];
                   
                }                
                //Disposing the objects  
                objReader.Dispose();   
                ObjCommand.Dispose();  
                objConn.Dispose();     
            }         
            catch (Exception ex)     
            {            
                MessageBox.Show(ex.Message); 
            }
