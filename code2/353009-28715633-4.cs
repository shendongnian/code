	using System.IO;//File, Directory, Path
	namespace Lib
	{
		/// <summary>
		/// Handy string methods
		/// </summary>
		public static class Strings
		{
			/// <summary>
			/// Extension method to write the string Str to a file
			/// </summary>
			/// <param name="Str"></param>
			/// <param name="Filename"></param>
			public static void WriteToFile(this string Str, string Filename)
			{
				File.WriteAllText(Filename, Str);
				return;
			}
			
			// of course you could add other useful string methods...
		}//end class
	}//end ns
