    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    
    namespace RegexFileTester
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string[] _files = Directory.GetFiles(".");
    			var _fileMatches =	from i in _files
    								where Regex.IsMatch(i, ".*test*.doc.*")
    								//where Regex.IsMatch(i, ".*cs")
    								select i;
    			foreach(var _file in _fileMatches)
    			{
    				Console.WriteLine(_file);
    			}
    		}
    	}
    }
