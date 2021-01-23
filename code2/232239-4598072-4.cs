    static bool checkValidPath(string path)
    {
        
        string quotelessPath = path.Replace("\"","");
        bool doesExist = Directory.Exists(quotelessPath);
        if(doesExist)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
