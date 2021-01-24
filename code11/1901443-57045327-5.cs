    public int GetStudentId()
    {
        try
        {
            // Validate connection
            if (con == null) throw new ArgumentNullException();
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("select max(Id)+1 from Student_Records", con);
            return (int)cmd.ExecuteScalar();
        }
        catch (SqlException)
        {
            // Return a well-known error code that a caller understands (if appropriate)
            return -1;
        }
        catch (Exception e)
        {
            // Log the exception
            Debug.WriteLine(e);
            // Re-throw the exception so program can continue - we
            // don't know what to do here, but maybe the caller will
            throw;
        }
    }
