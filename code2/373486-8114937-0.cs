            var ranges = new List<Range>() { dr1, dr2, dr3, dr4 };
            var starts = ranges.Select(p => p.Start);
            var ends = ranges.Select(p => p.End);
            var discreet = starts.Union(ends).Except(starts.Intersect(ends)).OrderBy(p => p).ToList();
            List<Range> result = new List<Range>();
            for (int i = 0; i < discreet.Count; i = i + 2)
            {
                result.Add(new Range(discreet[i], discreet[i + 1]));
            }
            return result;
