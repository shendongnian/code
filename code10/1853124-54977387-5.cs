    private Dictionary<string, string> ParsePathParameters(string path)
    {
        return GetSegments().ToDictionary(x => x.Span[0], x => x.Span[1]);
        IEnumerable<System.Memory<string>> GetSegments()
        {
            var segments = path?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
            for (int i = 0, l = segments.Length; i < l; i += 2)
                yield return segments[^i..i+1];
        }
    }
