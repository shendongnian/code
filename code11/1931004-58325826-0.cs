    using System.Linq;
    class Element
    {
        public string Key { get; }
        public string Value { get; }
        ...
    }
    IEnumerable<Element> elements = ...
    ILookup<string, string> lookup = elements.ToLookup(e => e.Key, e => e.Value);
