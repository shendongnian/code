    using System;
    using HtmlAgilityPack;	
    public class Program
    {
    	public static void Main()
    	{
    		string[] arr = { "abercrombie"};
    		for(int i=0;i<1;i++)
    			{
    				  string url = @"https://www.google.com/search?rlz=1C1CHBF_enCA834CA834&ei=lsfeXKqsCKOzggf9ub3ICg&q=" + arr[i] + "+ticker" + "&oq=abercrombie+ticker&gs_l=psy-ab.3..35i39j0j0i22i30l2.102876.105833..106007...0.0..0.134.1388.9j5......0....1..gws-wiz.......0i71j0i67j0i131j0i131i67j0i20i263j0i10j0i22i10i30.3zqfY4KZsOg";
    				  HtmlWeb web = new HtmlWeb();
    				  var htmlDoc = web.Load(url);
    				  var node = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'st']");
    				  Console.WriteLine(node.InnerHtml);
    			}
    	}
    }
