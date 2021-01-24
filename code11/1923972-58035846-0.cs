     public void Setup ( )
    {
        string ProfileDirect=Directory.GetCurrentDirectory()+"\\MyProfile";
        if ( !Directory.Exists ( ProfileDirect ) )
        {
            //create data folder if not exist 
            Directory.CreateDirectory ( ProfileDirect );
        }
        // Create new option with data folder 
        var options=new ChromeOptions();
        options.AddArgument ( @"user-data-dir="+ProfileDirect );
        // Instance new Driver , with our current profile data.
        Driver=new ChromeDriver(options);
        if ( !IsLoggedIn ( ) )
        {
            Login ( );
        }
    }
    public bool IsLoggedIn ( )
    {
        // Check if button logout is visible
        return Driver.FindElement(By.XPath ( "//a[contains(@href,'logout')]" ))!=null;
    }
    public void Login ( )
    {
        //Some code to login
    }
  
