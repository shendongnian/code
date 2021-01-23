    public void Write(string body, bool retryOnError)
    {
        for (int tries = MaxRetries; tries >= 0; tries--)
        {
            try
            {
                _outputfile.Write(body);
                _outputfile.Flush();
                break;
            }
            catch (Exception)
            {
                if (tries == 0)
                    throw; 
    
                _outputfile.Close();
                _outputfile = new StreamWriter(_filepath, true);
            }
        }
    }
