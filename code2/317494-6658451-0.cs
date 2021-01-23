	public static T1 SearchAgaistValues<T, T1>(
				Dictionary<string, string> input, 
				string key, 
				List<T1> values, 
				Func<string, T1, bool> match, 
				out string[] cmdParams)
				
