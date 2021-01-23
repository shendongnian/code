    public List<Invoice> GetInvoices(List<string> invoiceList) {
      List<Invoice> invoices = new List<Invoice>();
      
      Invoice inv;
      SqlDataReader dr;
      
      using (SqlConnection con = new SqlConnection(//connection string)) {
        using(SqlCommand cmd = new SqlCommand("dbo.getInvoices", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
          SqlParameter param = cmd.Parameters.Add("invoice", SqlDbType.VarChar);
          
          foreach(string i in invoiceList) {
            inv = new Invoice();
            param.Value = i;
            using (dr = cmd.ExecuteReader()) {
              while(dr.read())
              {
                // assign values from the database fields
                inv.Property = dr.GetString(0);
                
                // Add invoice to the result list
                invoices.Add(inv);
              }
            }
          }
        }
      }
      
      return invoices;
    }
