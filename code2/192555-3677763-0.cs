    namespace NewOrChanged
{
    class CompareDB
    {
        public string db1Name1;
        public string db1Name2;
         
        public void dbCompare()
        {     
        //SQL strings to use
            string strSQL = "SELECT [Column 1], [Column 2] FROM [Table 1]";
        //Open database Stings
            string db1Connection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + db1Name1 + ";";
            string db2Connection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + db1Name2 + ";";
           
            //Create Dictionary for the OLD database
          Dictionary<string, string> dictionaryOld = new Dictionary<string, string>();
            using (OleDbConnection connection1 = new OleDbConnection(db1Connection))
            {
                connection1.Open();
                using (OleDbCommand commandOld = new OleDbCommand(strSQL, connection1))
                {
                    using (OleDbDataReader readerOld = commandOld.ExecuteReader())
                    {
                        while (readerOld.Read())
                        {
                            dictionaryOld.Add(readerOld.GetString(0), readerOld.GetString(1));
                        }
                    }
                }
            } 
            //Create Dictionary for changed Records Database
            String value;
            Dictionary<string, string> dictionaryNew = new Dictionary<string, string>();
            using (OleDbConnection connection2 = new OleDbConnection(db2Connection))
            {
                connection2.Open();
                using (OleDbCommand commandNew = new OleDbCommand(strSQL, connection2))
                {
                    using (OleDbDataReader readerNew = commandNew.ExecuteReader())
                    {
                        while (readerNew.Read())
                        {
                            //Does the Key exist in both the New Database and the Dictionary?
                            if (dictionaryOld.TryGetValue(readerNew.GetString(0), out value))
                            {
                                //now check if the value of column 2 is the same. If it is Not add the Record to the dictionary
                                if (dictionaryOld[readerNew.GetString(0)] != (readerNew.GetString(1)))
                                {
                                dictionaryNew.Add(readerNew.GetString(0), readerNew.GetString(1));
                                }
                            }
                            //If the Key does not exist add the record to the Dictionary
                            else
                            {
                                dictionaryNew.Add(readerNew.GetString(0), readerNew.GetString(1));
                            }                            
                        }
                    }
                }
            }
            //Pop a window to verify the results
            string changeList= "";
            foreach (var pair in dictionaryNew)
            {
                changeList += "Key = "+ pair.Key +" , Value ="+ pair.Value +"\n";          
   
            }
            MessageBox.Show(changeList);
        }
    }
