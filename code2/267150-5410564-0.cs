                string  QueryText = "asp alliance"; //The search string
                string CatalogName = "searchcatalog"; //The name of your Index Server catalog
                int NumberOfSearchResults = 0;  
                DataSet SearchResults = new DataSet();  
      
                //Prevent SQL injection attacks - further security measures are recommended  
                QueryText = QueryText.Replace("'", "''");  
      
                //Build the search query  
                string SQL = "SELECT doctitle, vpath, Path, Write, Size, Rank ";  
                SQL += "FROM \"" + CatalogName + "\"..SCOPE() ";  
                SQL += "WHERE";  
                SQL += " CONTAINS(Contents, '" + QueryText + "') ";  
                SQL += "AND NOT CONTAINS(Path, '\"_vti_\"') ";  
                SQL += "AND NOT CONTAINS(FileName, '\".ascx\" OR \".config\" OR \".css\"') ";  
                SQL += "ORDER BY Rank DESC";  
      
                //Connect to Index Server and perform search query  
                try   
                {  
                    OleDbConnection IndexServerConnection = new OleDbConnection("Provider=msidxs;");  
                    OleDbCommand dbCommand = new OleDbCommand(SQL, IndexServerConnection);  
      
                    OleDbDataAdapter IndexServerDataAdapter = new OleDbDataAdapter();  
                    IndexServerDataAdapter.SelectCommand = dbCommand;  
                      
                    IndexServerDataAdapter.Fill(SearchResults);  
                    NumberOfSearchResults = SearchResults.Tables[0].Rows.Count;  
                }  
                catch (Exception ExceptionObject)  
                {  
                    //Query failed so display an error message  
                    NumberOfSearchResults = 0;  
                    LabelNumberOfResults.Text = "Problem with retrieving search results due to: " + ExceptionObject.Message;  
                    DataGridSearchResults.Visible = false;  
      
                }  
