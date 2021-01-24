    string queryString =   
      "SELECT CustomerID, CompanyName FROM dbo.Customers";  
    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);  
      
    DataSet customers = new DataSet();  
    adapter.Fill(customers, "Customers"); 
...
    private void BindComboBox()  
    {  
      comboBox1.DataSource = customers.Tables["Suppliers"];  
      comboBox1.DisplayMember = "ProductName";  
    }  
