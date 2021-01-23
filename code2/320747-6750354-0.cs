    static void Main(string[] args)
    {
			StringBuilder txt = new StringBuilder();
			txt.Append("Hello \n\n\r\t\t");
			txt.Append( Convert.ToChar(8232));
			System.Console.WriteLine("Original: <" + txt.ToString() + ">");
			System.Console.WriteLine("Cleaned: <" + CleanInput(txt.ToString()) + ">");
			System.Console.Read();
		}
		static string CleanInput(string strIn)
		{
			// Replace invalid characters with empty strings.
			return Regex.Replace(strIn, @"[^\w\.@-]", ""); 
		}
