    OdbcCommand cmd = new OdbcCommand("UPDATE PICTURES
                                          SET userid = ?,
                                              picturepath = ?
                                        WHERE userid = ?");
    cmd.Parameters.AddWithValue("@theuser", theUserid);
    cmd.Parameters.AddWithValue("@picpath", fileuploadpaths);
    cmd.Parameters.AddWithValue("@userid", userid);
    try
    {
      myConnection.executeNonQuery(cmd);
    }
    catch (Exception e)
    {
      Console.Write("Update failed: "+e.Message);
    }
