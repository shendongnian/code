    public static class MyExtensions
    {
        public static string ValueSafe(this XElement target)
        {
            if (target==null)
                { return ""; }
            else
                { return target.Value; }
        }
    }
   
