      class Program
      {
        static void Main(string[] args)
        {
          var table1 = GetCustomersFromFirst();
          var table2 = GetCustomersFromSecond();
    
          foreach (DataRow row in table1.Rows)
          {
            var foundRows = table2.Select("CustomerId = " + (string)row[0]);
            if (foundRows.Length == 1)
            {
              var foundRow = foundRows[0];
              foreach (DataColumn col in table1.Columns)
              {
                var valueOfColumnFromTable1 = row[col.Ordinal].ToString();
                var valueOfColumnFromTable2 = foundRow[col.Ordinal].ToString();
                if (String.Compare(valueOfColumnFromTable1, valueOfColumnFromTable2) != 0)
                {
                  //the colum values are not the same.
                }
                
              }
            }
            else
            {
              // Something is wrong since more than one matching record was found
              // or no matching records were found.
            }
          }
        }
    
        static DataTable GetCustomersFromFirst()
        {
          var dt = GetInitializedCustomerDataTable();
          var row = dt.NewRow();
          row[0] = "1";
          row[1] = "CompanyA";
          dt.Rows.Add(row);
          
          row = dt.NewRow();
          row[0] = "2";
          row[1] = "CompanyB";
          dt.Rows.Add(row);
          
          row = dt.NewRow();
          row[0] = "3";
          row[1] = "CompanyC";
          dt.Rows.Add(row);
    
          return dt;
        }
    
        static DataTable GetCustomersFromSecond()
        {
          var dt = GetInitializedCustomerDataTable();
          var row = dt.NewRow();
          row[0] = "1";
          row[1] = "CompanyA";
          dt.Rows.Add(row);
    
          row = dt.NewRow();
          row[0] = "2";
          row[1] = "CompanyD";
          dt.Rows.Add(row);
    
          row = dt.NewRow();
          row[0] = "3";
          row[1] = "CompanyC";
          dt.Rows.Add(row);
    
          return dt;
        }
    
        static DataTable GetInitializedCustomerDataTable()
        {
          var dt = new DataTable();
          dt.Columns.Add("CustomerId", typeof(string));
          dt.Columns.Add("CompanyName", typeof(string));
          return dt;
        }
      }
