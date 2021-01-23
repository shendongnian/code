    SqlConnection conn = new SqlConnection(myConnectionString);
    conn.Open();
    SqlCommand cmd = conn.CreateCommand();
    cmd.CommandText = "UPDATE Users SET username = @Username, password = @Password WHERE username = @OldUsername";
    cmd.Parameters.Add(new SqlParameter("@Username", txtNewUsername.Text));
    cmd.Parameters.Add(new SqlParameter("@Password", txtPassword.Text));
    cmd.Parameters.Add(new SqlParameter("@OldUsername", txtOldUsername.Text));
    try
    {
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        Console.Writeline(String.Format("{0} thrown: {1}", ex.GetType().Name, ex.Message));
    }
