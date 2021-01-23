    public Invoice GetInvoice(string invoice)
    {
          SqlConnection con = new SqlConnection(//connection string);
          SqlCommand cmd = new SqlCommand("dbo.getInvoices", con);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("invoice", SqlDbType.VarChar).Value = invoice;
          SqlDataReader dr;
          Invoice inv = new Invoice();
          try{
                con.Open();
                dr = cmd.ExecuteReader
                while(dr.read())
                {
                     //assign values from the database fields
                }
          }
          catch{}
          finally
          {
            con.Close();
          }
    }
