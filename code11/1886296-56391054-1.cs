            try
            {
                RemoveRecordsWithSameName();
            }
            catch (SqlException ex)
            {
                 if (ex.Errors.Count > 0) // Assume the interesting stuff is in the first error
                {
                 switch (ex.Errors[0].Number)
                {
                case 547: // Foreign Key violation but you have to check number
                    MakeRecordsWithSameNameInActive();
                    break;               
                default:
                    throw new DataAccessException(ex);
                }
                }
    
            }          
            catch(Exception ex)
            {
              //process regular exception
            }
