    // @nuget: HtmlAgilityPack
    
    using System;
    using System.Xml;
    using HtmlAgilityPack;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var html = @"https://www.w3schools.com/html/html5_video.asp";
    
            HtmlWeb web = new HtmlWeb();
    
            var htmlDoc = web.Load(html);
    
            var node = htmlDoc.DocumentNode.SelectSingleNode("//video");
    
            Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml + "\n Node id is: " + node.Attributes["id"].Value);		
    	}
    }
