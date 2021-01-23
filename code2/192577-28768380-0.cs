    // LinqPad .ReplaceAll and SafeFileName
	void Main()
	{
	
		("a:B:C").Replace(":", "_").Dump();						// can only replace 1 character for one character => a_B_C
		("a:B:C").Replace(":", null).Dump();					// null replaces with empty => aBC
		("a:B*C").Replace(":", null).Replace("*",null).Dump();	// Have to chain for multiples 
		
		// Need a ReplaceAll, so I don't have to chain calls
		
		
		("abc/123.txt").SafeFileName().Dump();
		("abc/1/2/3.txt").SafeFileName().Dump();
		("a:bc/1/2/3.txt").SafeFileName().Dump();
		("a:bc/1/2/3.txt").SafeFileName('_').Dump();
		//("abc/123").SafeFileName(':').Dump(); // Throws exception as expected
	
	}
	
	
	static class StringExtensions
	{
	
		public static string SafeFileName(this string value, char? replacement = null)
		{
			return value.ReplaceAll(replacement, ':','*','?','"','<','>', '|', '/', '\\');
		}
		
		public static string ReplaceAll(this string value, char? replacement, params char[] charsToGo){
		
			if(replacement.HasValue == false){
					return string.Join("", value.AsEnumerable().Where(x => charsToGo.Contains(x) == false));
			}
			else{
					
				if(charsToGo.Contains(replacement.Value)){
					throw new ArgumentException(string.Format("Replacement '{0}' is invalid.  ", replacement), "replacement");
				}
			
				return string.Join("", value.AsEnumerable().Select(x => charsToGo.Contains(x) == true ? replacement : x));
			}
			
		}
		
	}
