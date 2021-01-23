    public class FourElevenLookup
    {
        private const string URL = "http://www.canada411.ca/search/";
        private const string TYPE_PARAM = "?stype=si";
        private const string WHAT_PARAM = "&what=";
        private const string WHERE_PARAM = "&where=";
        public static List<SearchResult> GetResults(string lastName, string postalCode)
        {
            List<SearchResult> results = new List<SearchResult>();
            string fullUrl = URL + TYPE_PARAM + WHAT_PARAM + lastName +
                WHERE_PARAM + postalCode.Replace(" ", "+");
            string rawText = GetHtml(fullUrl);
            Regex getListings = new Regex("\\<\\!\\-\\- (listingDetail|listing) \\-\\-\\>(?<content>" + 
                "(.(?!(\\<\\!\\-\\- (\\/ listingDetail|listing) \\-\\-\\>)))*)", RegexOptions.Singleline);
            MatchCollection mc = getListings.Matches(rawText);
            List<string> rawListings = new List<string>();
            for (int i = 0; i < mc.Count; i++)
                rawListings.Add(mc[i].Groups["content"].Value);
            Regex parseListing = new Regex("\\<div class=\"c411ListingInfo\"\\>(.(?!a href=))*\\<a href\\=(.(?!\\>))*\">" + 
                "(?<name>[\\w- ]*)\\<\\/a\\>\\<br\\/\\>(.(?!span))*\\<span class\\=\"address\"\\>" + 
                "(?<address>(.(?!\\/span\\>))*)", RegexOptions.Singleline);            
            rawListings.ForEach(s =>
            {
                Match m = parseListing.Match(s);
                results.Add(new SearchResult()
                {
                    Name = m.Groups["name"].Value,
                    Address = m.Groups["address"].Value.Replace("<br/>", "")
                });
            });
            return results;
        }
        private static string GetHtml(string strURL)
        {
            string result;
            WebResponse objResponse;
            WebRequest objRequest = System.Net.HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr =
            new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
        }
    }
    public struct SearchResult 
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
