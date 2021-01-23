    bool useName = String.IsNullOrEmpty(txtUsername.Text);
    StringBuilder query = new StringBuilder("select * from xy where id=@id");
    if(useName) 
     query.Append(" AND name=@name");
    
    SqlCommand cmd = new SqlCommand(query.ToString());
    // add ID param
    if(useName) {
      // add name param
    }
