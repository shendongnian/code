        public static string ShallowValue(this XElement element)
        {
            return element
                   .Nodes()
                   .OfType<XText>()
                   .Aggregate(new StringBuilder(),
                              (s, c) => s.Append(c),
                              s => s.ToString());
        }
