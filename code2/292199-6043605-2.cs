    public class A
    {
        public string TellMeWhy()
        {
            return B.TheReasen;
        }
        sealed private class B
        {
            internal static string TheReasen = 
                "How would you access any of these members " +
                "if they all have to be private?";
        }
    }
