    private string MaskName(string name)
    {
        var parts = name.Split(',');
        var subparts = parts[1].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < subparts.Length; i++)
        {
            var subpart = subparts[i];
            subparts[i] = subpart[0] + new string('X', subpart.Length - 1);
        }
        return parts[0] + ", " + string.Join(" ", subparts);
    }
