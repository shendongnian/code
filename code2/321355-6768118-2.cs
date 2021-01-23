    // ReSharper disable PossibleMultipleEnumeration
    		public void DoSomething(IEnumerable<string> list)
    		{
    			if (list.Any()) // <- here
    			{
    				// ...
    			}
    			foreach (var item in list) // <- and here
    			{
    				// ...
    			}
    		}
    // ReSharper restore PossibleMultipleEnumeration
