    [HttpPost]
    [Route("api/geom")]
    public async Task<HttpResponseMessage> AddRef([FromBody]Peticion empObj)
    {
    	using (SqlConnection con = new SqlConnection("connection-string"))
    	{
    		string query = "query";
    		using (SqlCommand querySaveStaff = new SqlCommand(query))
    		{
    			querySaveStaff.Connection = con;
    			await con.OpenAsync();
    			await querySaveStaff.ExecuteNonQueryAsync();
    			con.Close(); // in this case not needed will be closed when disposed
    		}
    	}
    	return Request.CreateResponse(HttpStatusCode.OK);
    }
