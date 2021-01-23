        public static void ExcelOperations(string ConnectionString)
        {
            try
            {
                DataTable Sheets = new DataTable();
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    //Retrieve the Sheets
                    Sheets = connection.GetSchema("Tables");
                    //Display the Sheets
                    foreach (DataRow sheet in Sheets.Rows)
                    {
                        Console.WriteLine(sheet["TABLE_NAME"]);
                    }
                    //Take the First Sheet
                    string firstSheet = Sheets.Rows[0][2].ToString();
                    //Retrieve contents
                    DataSet Contents = new DataSet();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("select FirstName,LastName,Email,Mobile from [" + firstSheet + "]", connection))
                    {
                        adapter.Fill(Contents, "MyTable");
                    }
                    //Display the contents
                    foreach (DataRow content in Contents.Tables["MyTable"].Rows)
                    {
                        Console.WriteLine(content[0] + " | " + content[1] + " | " + content[2] + " | " + content[3]);
                    }
                    Console.WriteLine();
                    //Remove First Row; Note: This is not heading!
                    Contents.Tables["MyTable"].Rows.RemoveAt(0);
                    //Since the first row is removed, Second Row becames first row now.
                    //Clearing the LastName of our First Row.
                    Contents.Tables["MyTable"].Rows[0][1] = "";
                    //Displaying the Contents
                    foreach (DataRow content in Contents.Tables["MyTable"].Rows)
                    {
                        Console.WriteLine(content[0] + " | " + content[1] + " | " + content[2] + " | " + content[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
