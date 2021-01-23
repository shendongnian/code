	class Program
	{
		private static void Main(string[] args)
		{
		    object d = new object();
		    if (<Main>o__SiteContainer0.<>p__Site1 == null)
		    {
		        <Main>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, Program>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Program), typeof(Program)));
		    }
		    Console.WriteLine(<Main>o__SiteContainer0.<>p__Site1.Target(<Main>o__SiteContainer0.<>p__Site1, d));
		    Program y = d as Program;
		    Console.WriteLine(y);
		    bool z = d is Program;
		    Console.WriteLine(z);
		}
	}
