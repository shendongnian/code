    private Dictionary<string, string> ParsePathParameters(string path)
    {
        return GetSegmentPairs().ToDictionary(x => x.k, x => x.v);
        IEnumerable<(string k, string v)> GetSegmentPairs()
        {
            var segments = path?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                    ?? new string[0];
            for (int i = 0, l = segments.Length; i < l; i += 2)
                yield return (segments[i+0], segments[i+1]);
        }
    }
