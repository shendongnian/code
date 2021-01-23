    using System;
    using System.Collections.Generic;
    using Fizzler.Systems.HtmlAgilityPack;
    using RestSharp;
    using RestSharp.Contrib;
    
    namespace BlogSearch
    {
        public class BlogSearcher
        {
            const string Site = "http://yourblog.com";
    
            public static List<SearchResult> Get(string searchTerms, int count=10)
            {            
                var searchResults = new List<SearchResult>();
    
                var client = new RestSharp.RestClient(Site);
                //note 10 is the page size for the search results
                var pages = (int)Math.Ceiling((double)count/10);
    
                for (int page = 1; page <= pages; page++)
                {
                    var request = new RestSharp.RestRequest
                                      {
                                          Method = Method.GET,
                                          //the part after .com/
                                          Resource = "page/" + page
                                      };
    
                    //Your search params here
                    request.AddParameter("s", HttpUtility.UrlEncode(searchTerms));
    
                    var res = client.Execute(request);
    
                    searchResults.AddRange(ParseHtml(res.Content));
                }
    
                return searchResults;
            }
    
            public static List<SearchResult> ParseHtml(string html)
            {            
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var results = doc.DocumentNode.QuerySelectorAll("#content-main > div");
    
                var searchResults = new List<SearchResult>();
                foreach(var node in results)
                {
                    bool add = false;
                    var sr = new SearchResult();
                    
                    var a = node.QuerySelector(".posttitle > h2 > a");
                    if (a != null)
                    {
                        add = true;
                        sr.Title = a.InnerText;
                        sr.Link = a.Attributes["href"].Value;
                    }
    
                    var p = node.QuerySelector(".entry > p");
                    if (p != null)
                    {
                        add = true;
                        sr.Exceprt = p.InnerText;
                    }
    
                    if(add)
                        searchResults.Add(sr);
                }
    
                return searchResults;
            }
    
    
        }
        public class SearchResult
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Exceprt { get; set; }
        }
    }
