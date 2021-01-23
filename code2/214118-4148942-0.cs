    public void Write(string body, bool retryOnError)
    {
        try
        {
            m_Outputfile.Write(body);
            m_Outputfile.Flush();
        }
        catch (Exception)
        {
            if(!retryOnError)
                throw; 
            // try to re-open the file...
            m_Outputfile = new StreamWriter(m_Filepath, true);
            Write(body, false);
        }
    }
