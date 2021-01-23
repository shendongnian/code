	using System;
	using System.IO;
	class Program
	{
		static void Main()
		{
			//
			// Write file containing the date with BIN extension
			//
			string n = string.Format("text-{0:yyyy-MM-dd_hh-mm-ss-tt}.bin",
				DateTime.Now);
			File.WriteAllText(n, "abc");
		}
	}
