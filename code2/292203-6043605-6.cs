    public class A
    {
        public string TellMeWhy()
        {
            return B.TheReason;
        }
        sealed private class B
        {
            internal static string TheReason = 
                "How would you access any of these members " +
                "if they all have to be private?";
        }
    }
