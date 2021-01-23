    public static class Extensions
    {
        public static void DoSomething(this string s,Action<string> action)
        {
            var something = Enumerable.Range(1,100).Select(i=> String.Format("{0}_{1}",s,i));
            foreach (var ss in something)
            {
                action(ss);
            }
        }
    }
