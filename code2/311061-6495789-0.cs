    namespace ConsoleApplication3
    {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Xml.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			XElement root = XElement.Load("XMLFile1.xml");
			IEnumerable<string> dirs = from el in root.Elements("dir")	//was directorylist
										 select el.Value;
			foreach (var dir in dirs)
			{
				Console.WriteLine(dir);
			}
			Console.ReadKey();
		}
    }
