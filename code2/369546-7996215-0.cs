        add-type "
	using System.Collections.Generic;
	namespace myTest
	{
		public class stuff
		{
			public int val;
			public stuff(int val)
			{
				this.val = val;
			}
		}
		public class tata : List<stuff>
		{
			int val;
		}
	} " -IgnoreWarnings
	
	$example = new-object myTest.stuff(1)
	$example2 = new-object myTest.tata
	$example2.GetType().Name
