    {
        
       
        // A.
        // Create the Regex.
        Regex r = new Regex(@"\s+");
        // B.
        // Remove multiple spaces.
        string s3 = r.Replace(str, @" ");
        return s3;
    }
