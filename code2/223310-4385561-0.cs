    public void perform()
    {
     Object[] works = ...;
     System.Threading.Tasks.Parallel.ForEach(works, each => { PerformUserWorkItem(each); });
     Server.Transfer("progress.aspx");
    }
    
    private static void PerformUserWorkItem(Object stateObject)
        {
            ...
        }
