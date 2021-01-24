            try
            {
                RemoveRecordsWithSameName();
            }
            catch(ForeignKeyException e)
            {
                MakeRecordsWithSameNameInActive();
            }
            catch(Exception ex)
            {
              //process regular exception
            }
