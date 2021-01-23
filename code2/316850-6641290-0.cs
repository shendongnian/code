    private void somevoid()
            {
    
                try
                {
                    int i = 1;
                    int z = 0;
                    int g = i / z;
                }
    
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
