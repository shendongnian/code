    //sample code
    public sealed class BaseWebPage : Page
    {
    static BaseWebPage instance=null;
    static readonly object padlock = new object();
    BaseWebPage()
    {
    }
    public static BaseWebPage Instance
    {
        get
        {
            if (instance==null)
            {
                lock (padlock)
                {
                    if (instance==null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
