        var dataTable = new DataTable();
        
                    // Get All Rows
                    var rows = dataTable.Rows;
    // Loop Over all rows                
    foreach (DataRow dataRow in rows)
                    {
                        //Get All Columns in Rows
                        var rowArray = dataRow.ItemArray;
            
    foreach (var col in rowArray)
                        {
                            if (col is int)
                            {
                                var number = (int) col;
                                Console.WriteLine(number.ToString());
                            }
                            if (col is string)
                            {
                                var number = (string) col;
                                Console.WriteLine(number.ToString());
                            }
                            if (col is double)
                            {
                                var number = (double) col;
                                Console.WriteLine(number.ToString());
                            }
                        }
                    
