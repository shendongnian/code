    using System;
    
    public class Program
    {
        static void Main()
        {
            string href = @"issue?status=-1,1,2,3,4,5,6,7&amp;
    @sort=-activity&amp;@search_text=&amp;@dispname=Show Assigned&amp;
    @filter=status,assignedto&amp;@group=priority&amp;
    @columns=id,activity,title,creator,status&amp;assignedto=244&amp;
    @pagesize=50&amp;@startwith=0";
    
            href = System.Web.HttpUtility.HtmlDecode(href);
    
            var querystring = System.Web.HttpUtility.ParseQueryString(href);
    
            Console.WriteLine(querystring["assignedto"]);
        }
    }
