        void PrintNames(StringBuilder result, string indent, XElement el)
        {
            var attr = el.Attributes("name");
            if (attr != null)
            {
                result.Append(indent);
                result.Append(attr.Value);
                result.Append(System.Environment.NewLine);
            }
            foreach(var child in el.Elements())
            {
                PrintNames(result, indent + " ", child);
            }
        }
    
    ...
    
    var sb = new StringBuilder();
    PrintNames(sb, String.Empty, xdoc.Root);
