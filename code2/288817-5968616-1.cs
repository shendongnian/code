     public class nytimesnews
     {
           // name of these variables are just like the  data tags in json string
           public string offset { get; set; }      
           public result[] results;
           public string total { get; set; }
     }
     public class results
     {
           public string body { get; set; }
           public string byline { get; set; }
           public string date { get; set; }
           public string title { get; set; }
           public string url { get; set; }
     }
