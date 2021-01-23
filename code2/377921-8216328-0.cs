     SqlCommand myCommand = new SqlCommand("ViewBusinessInfo", conn);
     SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand))
     DataTable dt = new DataTable();
     myAdapter.Fill(dt);
     ...
     
