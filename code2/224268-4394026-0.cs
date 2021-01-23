    IEnumerable<string> ExpandWildcards(IEnumerable<string> lines)
    {
        return lines.SelectMany(ExpandWildcards);
    }
    IEnumerable<string> ExpandWildcards(string input)
    {
        string[] parts = input.Split(',');
        var expanded = parts.Select(ExpandSingleItem);
        return expanded.CartesianProduct().Select(line => line.JoinStrings(","));
    }
    
    static readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    IEnumerable<string> ExpandSingleItem(string item)
    {
        if (item == "*")
            return _chars.Select(c => string.Format("+{0},-{0}", c));
        return new[] { item };
    }
    
    static class Extensions
    {
        // CartesianProduct method by Eric Lippert (http://blogs.msdn.com/b/ericlippert/archive/2010/06/28/computing-a-cartesian-product-with-linq.aspx)
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences) 
        { 
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() }; 
            return sequences.Aggregate( 
                emptyProduct, 
                (accumulator, sequence) =>  
                from accseq in accumulator  
                from item in sequence  
                select accseq.Concat(new[] {item}));                
        }
        
        public static string JoinStrings(this IEnumerable<string> strings, string separator)
        {
            return strings.Aggregate(
                            default(StringBuilder),
                            (sb, item) => sb == null
                                ? new StringBuilder(item)
                                : sb.Append(separator).Append(item),
                            sb => sb.ToString());
        }
    }
