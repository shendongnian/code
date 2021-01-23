    if(reader.IsDBNull("CustomerId")
    {
       Id = Convert.ToInt32(reader["CustomerID"]);
    }
    else
    {
       Id = NULL;
    }
