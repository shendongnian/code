    using(IDataReader NewReader = (SqlDataReader)(SqlDatabase.ExecuteReader(SqlCommand)))
    {
        try
        {
            /* Do some work with NewReader. */
        }
        catch /* As much 'catch' blocks as necessary */
        {
            /* Handle exceptions */
        }
    }
