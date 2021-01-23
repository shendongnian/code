            catch (StoredProcException spEx)
            {
                switch (spEx.ReturnValue)
                {
                    case 6:
                        UserMessageException umEx= new UserMessageException(spEx.Message);
                        throw umEx;
                }
            }
