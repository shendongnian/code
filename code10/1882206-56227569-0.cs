    using System.Linq;
    using HtmlAgilityPack;
        static void Main(string[] args)
        {
            var validstring =
                "This is the data received from external<div> data string</ div >. string <div>valid string</ div >";
            var invalidstring =
                "This is the data received from external <p>data string</p>. string <div>valid string</div>";
            var b1 = IsStringValid(validstring); // returns true
            var b2 = IsStringValid(invalidstring); // returns false
        }
        static bool IsStringValid(string str)
        {
            var pageDocument = new HtmlDocument(); // Create HtmlDocument
            pageDocument.LoadHtml(str); // Load the string into the Doc
            // check if the descendant nodes only have the names "div" and "#text"
            // "#text" is the name of any descendant that isn't inside a html-tag
            return !pageDocument.DocumentNode.Descendants().Any(node => node.Name != "div" && node.Name != "#text");
        }
