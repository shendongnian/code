    private bool test()
        {
            try
            {
                int i = 0;
               int u = 10 / i;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
               
            }
            return true;
        }
