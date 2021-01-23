    public List<Product> GetAllProducts()
    {
    	List<Product> prodList = new List<Product>();
    	using (SqlConnection connection = new SqlConnection(GetConnection()))
    	{
    		using (SqlCommand comm = new SqlCommand("GetAllProducts", connection))
    		{
    			connection.Open();
    			comm.CommandType = CommandType.StoredProcedure;
    			using (SqlDataReader dr = comm.ExecuteReader())
    			{
    				try
    				{
    					while (dr.Read())
    					{
    						Product obj = new Product();
    						obj.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
    						obj.Product = dr["Product"].ToString();
    						//etc....                                                                       
    
    						prodList.Add(obj);
    					}
    				}
    			}
    		}
    	}
    
    	return prodList;
    }
