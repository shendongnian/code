    [HttpPost]
    public ActionResult addimage(HttpPostedFileBase ImageFile) 
    { 
      byte[] file = new byte[ImageFile.ContentLength];
      using (SqlConnection con = new SqlConnection(connectionString)) 
      { 
        using (SqlCommand cmd = new SqlCommand("dbo.addimage", con)) 
        { 
          cmd.CommandType = CommandType.StoredProcedure; 
          cmd.Parameters.AddWithValue("@tname", file);
          con.Open(); 
          status = cmd.ExecuteNonQuery(); 
        } 
      }
    }
