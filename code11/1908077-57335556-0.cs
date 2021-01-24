    List<TicketExtendedFieldModel> list = new List<TicketExtendedFieldModel>();
    
    using (SqlCommand cmd = new SqlCommand("GetExtendedFields", con))
    {
       con.Open();
       cmd.CommandType = CommandType.StoredProcedure;
    
       SqlDataReader rdr = cmd.ExecuteReader();
       while (rdr.Read())
       {
          TicketExtendedFieldModel obj = new TicketExtendedFieldModel();
          // your properties from TicketExtendedFieldModel and then
          // obj.name = Convert.ToString(rdr["name"]);
          list.Add(obj);
       }
       con.Close();
    }
