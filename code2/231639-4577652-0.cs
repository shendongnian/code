    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
    	    List<FileInfo> files = new List<FileInfo>();
    		files.Add(new FileInfo("OhNo.jpg"));
    		
    		files.Add(new FileInfo("OhYes.jpg"));
    					
    		files.Add(new FileInfo("OhMy.pcx"));
    		
    		files.Add(new FileInfo("OhTrue.png"));
    		
    	    IEnumerable<FileInfo> result =  files.Where(
                 f => new string[] { ".jpg", ".png" }.Contains(f.Extension));
    		
    		foreach(var r in result) Console.WriteLine("{0}", r);
        }
    }
