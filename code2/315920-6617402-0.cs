    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class MyClass
    {
       static void Main(string[] args)
       {
    	   string test = "SiteA:Pages:1,SiteB:Pages:4,SiteA:Documents:6";
    	   var sites = test.Split(',')
    		   .Select(p => p.Split(':'))
    		   .Select(s => new { Site = s[0], Key = s[1], Value = s[2] })
    		   .GroupBy(s => s.Site)
    		   .ToDictionary(g => g.Key, g => g.ToDictionary(e => e.Key, e => e.Value));
    
    	   foreach (var site in sites)
    		   foreach (var key in site.Value.Keys)
    		       Console.WriteLine("Site {0}, Key {1}, Value {2}", site.Key, key, site.Value[key]);
    
    	   // in your preferred format:
    	   var SiteA = string.Join(",", sites["SiteA"].Select(p => string.Format("{0}:{1}", p.Key, p.Value)));
    	   var SiteB = string.Join(",", sites["SiteB"].Select(p => string.Format("{0}:{1}", p.Key, p.Value)));
    
    	   Console.WriteLine(SiteA);
    	   Console.WriteLine(SiteB);
       }
    }
