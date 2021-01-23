    public static int main(String[] args)
    {
        try 
        {
           // other code
    
           return 0;
        }
        catch (Exception ex)
        {
           Console.Error.WriteLine(ex);
    
           // Save to file, in case this is an application that runs in the background
           // Make sure the directory exists and is writable though.
           System.IO.File.WriteAllText("C:\\TEMP\\Exception.txt", ex.ToString());
    
           return 1;
        }
    }
