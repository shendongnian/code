    public void Write(string body, bool retryOnError)
    {
        for (int tries = MaxRetries; tries >= 0; tries--)
        {
            try
            {
                m_Outputfile.Write(body);
                m_Outputfile.Flush();
                break;
            }
            catch (Exception)
            {
                if (tries = 0)
                    throw; 
    
                m_Outputfile = new StreamWriter(m_Filepath, true);
            }
        }
    }
