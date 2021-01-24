        using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		var doc = new HtmlAgilityPack.HtmlDocument();
    		var html = "<div class='datagrid-cell cell-artist'><div class='ellipsis'><a class='datagrid-label datagrid-label-main' itemprop='byArtist' title='Drake' href='/ru/artist/246791'>Drake</a></div></div>";
    		doc.DocumentNode.AppendChild(HtmlAgilityPack.HtmlNode.CreateNode(html));
    		foreach (var node in doc.DocumentNode.SelectNodes("//a[@itemprop='byArtist']"))
    		{
    			Console.WriteLine(node.Attributes["title"].Value);
    		}
    	}
    }
