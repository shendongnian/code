    bool succeeded = false;
    
    do
    {
        try
        {
            m_Outputfile.Write(body); 
            m_Outputfile.Flush(); 
            succeeded = true;
        }
        catch(...)
        {
        }
    }
    while (!succeeded)
