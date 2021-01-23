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
                    if (NotFailedOnce = !NotFailedOnce)
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
