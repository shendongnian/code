	using System;
	using System.Collections.Generic;
	using System.IO;
	public static class Extensions
	{
		public static string Replace(this string source, string oldString, string newString, StringComparison comp)
		{
			int index = source.IndexOf(oldString, comp);
			
			// Determine if we found a match
			bool MatchFound = index >= 0;
			if (MatchFound)
			{
				// Remove the old text
				source = source.Remove(index, oldString.Length);
				// Add the replacemenet text
				source = source.Insert(index, newString);            
			}
			return source;
		}
	}
