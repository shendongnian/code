    private static void Main(string[] args)
    {
        if (<Main>o__SiteContainer0.<>p__Site1 == null)
        {
            <Main>o__SiteContainer0.<>p__Site1 = 
            CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(
            CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Program)));
        }
        TestServer server = new TestServer(
        <Main>o__SiteContainer0.<>p__Site1.Target.Invoke(
        <Main>o__SiteContainer0.<>p__Site1, GetPort()));
        Console.ReadLine();
    }
