    if (reader != null)
    {
      ((IDisposable)reader).Dispose(); 
      // somthing like that .. do the same for con and cmd objects or wrap them in a using() {}
    }
    cmd = new SqlCommand("usp_getmemberdetail", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add(new SqlParameter("@MEMBERSHIPGEN", SqlDbType.Int, 5));
    cmd.Parameters["@MEMBERSHIPGEN"].Value = membershipgen; 
