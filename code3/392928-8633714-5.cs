    public static bool IsRunningFromNetwork(string rootPath)
    {
        try
        {
            System.IO.DriveInfo info = new DriveInfo(rootPath);
            if (info.DriveType == DriveType.Network)
            {
                return true;
            }
            return false;
        }
        catch
        {
            try
            {
                Uri uri = new Uri(rootPath);
                return uri.IsUnc;
            }
            catch
            {
                return false;
            }
        }
    }
    static void Main(string[] args) 
    {
        Console.WriteLine(IsRunningFromNetwork(AppDomain.CurrentDomain.BaseDirectory));
    }
