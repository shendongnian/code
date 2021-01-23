	using (SqlConnection con = new SqlConnection(Conn.Activated))
	using (SqlCommand com = new SqlCommand("AddBook", con))
	{
		com.CommandType = CommandType.StoredProcedure; 
		com.Parameters.AddWithValue("@BookISBN", txtISBN.Text);             
		
		com.ExecuteNonReader()
		// close can be omitted since you are already using the 'using' statement which automatically closes the connection
		con.Close(); 
	}
} 
