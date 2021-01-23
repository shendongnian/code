    public void Write(string body)
    {
            bool NotFailedOnce = true;            
            while (true)
            {
                try
                {
                     _outputfile.Write(body);
                     _outputfile.Flush();           
                     return;                    
                }
                catch (Exception)
                {
                    NotFailedOnce = !NotFailedOnce;
                    if (NotFailedOnce)
                    {
                        throw;
                    }
                    else
                    {
                         m_Outputfile = new StreamWriter(m_Filepath, true);
                    }
                }
          }        
    }
