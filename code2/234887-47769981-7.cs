	internal class MyDbConfiguration : DbConfiguration
	{
		protected internal MyDbConfiguration ()
		{           
			AddInterceptor(new UtcInterceptor());
		}
	}
