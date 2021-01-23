    // Extension methods
    internal static bool IsBidder(this XElement bidder, string person)
    {
        return (string) bidder.Element("personref")
            .Attribute("person") == person;
    }
    
    internal static IEnumerable<XElement> ElementsAfterFirst
        (this IEnumerable<XElement> source, XName name)
    {
        var first = source.FirstOrDefault();
        if (first != null)
        {
            foreach (var element in first.ElementsAfterSelf(name))
            {
                yield return element;
            }
        }
    }
    var query = doc
        .Descendants("open_auction")
            .Where(x => x.Elements("bidder")
                   // All the person20 bids...
                   .Where(b => b.IsBidder("person20"))
                   // Now project to bids after the first one...
                   .ElementsAfterFirst("bidder")
                   // Are there any from person51? If so, include this auction.
                   .Any(b => b.IsBidder("person51"))
                   );
