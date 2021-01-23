        var reFormatted = new List<string>();
        foreach (var roughOne in toExplain) 
        {
            // example of roughOne "Operations\t325\t65\t0\t10\t400"
            var segments = roughOne.Split("\t");
            var firstSegment = segments.First();
            var sb = new StringBuilder();
            foreach (var otherSegment in segments.Skip(1))
            {
                sb.Append(firstSegment);
                sb.Append("|")
                sb.Append(otherSegment);
                sb.Append("\r\n");
            }
            reFormatted.Add(sb.ToString());
        }
