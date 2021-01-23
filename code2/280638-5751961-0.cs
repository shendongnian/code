    using (SqlConnection cn = new SqlConnection(...))
    {
        using (SqlCommand cmd = new SqlCommand(cn, "select cat_price from category where cat_itemID= 'A001'"))
        {
            //Execute the query and just get the first result.
            int value = (int)cmd.ExecuteScalar();
        }
    }
