    public static void checkFileNumber(string directoryToCheck, int maxNumber )
    {
        if ( Directory.Exists( directoryToCheck ) )
        {
            if ( Directory.GetFiles( directoryToCheck ).Length > maxNumber )
            {
                throw new Exception("Too many files in " + directoryToCheck);
            }
        }
    }
