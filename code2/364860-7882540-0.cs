    void Original()
    {
        int i = 0;            
        while(i <= 10)
        {
            Debug.WriteLine(i);
            i++;
            if (Process(i))
            {
                break;
            }
        }
    }
    bool Process(int i)
    {
        for(int j = 0; j < 3; j++)
            if (i > 5)
            {
                return true;
            }
        return false;
    }
