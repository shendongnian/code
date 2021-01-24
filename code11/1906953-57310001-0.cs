    if (reader.HasRows)
    {
        #region Result #1
        // (you can use reader.Read() to iterate through all rows of the result)
        while (reader.Read())
        {
            // Populate data from the first result into your model object
        }
        #endregion
        #region Result #2
        reader.NextResult();
        if (reader.HasRows)
        {
            // Populate data from the second result into your model object/s
            while (reader.Read())
            {
                 // your statements come here
            }
        }
        #endregion
    }
