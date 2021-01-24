    	public string[] GetParentDomains(string[] input) {
		return input
			.SelectMany(s => s.Split(' '))
			.SelectMany(s => {
				        string[] splitDomain = s.Split('.');
						return  Enumerable.Range(0, splitDomain.Length)
							.Select(counter => 
									String.Join(".", splitDomain.Skip(counter)))
							.ToArray(); 
					   })
			.ToArray();				 
	}
