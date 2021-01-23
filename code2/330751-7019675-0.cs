    // let IEnumerable<string> lines be
    // a list of lines in the input.
    string s = lines
        .Aggregate(
        // seed accumulator with anonymous class 
        // including StringBuilder and the last
        // header group
        new {
            builder = new StringBuilder(),
            lastheader = new string[1] 
        },
        // accumulator function for each item
        (acc, line) =>
        {
            var parts = line.Split(new char[] {'-'}, 2);
            string headerpart = parts[0];
            string itempart = parts.Length == 1 ? null : line.Substring(line.IndexOf('-'));
            bool firstline = acc.builder.Length == 0;
            // Case 1: The line contains no hyphen
            if (parts.Length == 1)
            {
                if (!firstline) acc.builder.AppendLine();
                acc.builder.AppendLine(line);
                acc.lastheader[0] = null;
            }
            // Case 2: The line contains a hyphen, and
            // the header is the same as the header on the previous
            // line.  Only output the item.
            else if (acc.lastheader[0] == parts[0])
            {
                 acc.builder.AppendLine(itempart);
            }
            // Case 3: The line contains a hyphen, and
            // the header is not the same as the header on the previous
            // line.  Output the header on one line, and then the item
            // on the subsequent line.
            else
            {
                acc.lastheader[0] = headerpart;
                if (!firstline) acc.builder.AppendLine();
                acc.builder.AppendLine(headerpart);
                acc.builder.AppendLine(itempart);
            }
            // Finally, return the mutated accumulator.
            return acc;
        },
        // When finished, convert the builder to a string
        // and return the complete string.
        acc => acc.builder.ToString());
