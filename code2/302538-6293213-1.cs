    private void SaveErrorMessage(string errorMessage)
    {
        string errorFile = null;
        for( int x = 0; x < Int32.MaxValue; ++x )
        {
            errorFile = string.Format(CultureInfo.InvariantCulture, "error-{0}.txt", x);
            if( !System.IO.File.Exists(errorFileTest) )
            {
                break;
            }
        }
 
        File.WriteAllText(errorFile, errorText);
    }
