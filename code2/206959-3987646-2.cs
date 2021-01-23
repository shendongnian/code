    if(! reader.IsDBNull(reader.GetOrdinal("CustomerId"))
    {
       Id = Convert.ToInt32(reader["CustomerID"]);
    }
    else
    {
       Id = NULL;
    }
