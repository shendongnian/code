    private int SomeMagic(IEnumerable<string> source, IEnumerable<string> target)
    {
        /* Some obvious checks for `source` and `target` lenght / nullity are ommited */
        // searched pattern
        var pattern = target.ToArray();
        // candidates in form `candidate index` -> `checked length`
        var candidates = new Dictionary<int, int>();
        // iteration index
        var index = 0;
        // so, lets the magic begin
        foreach (var value in source)
        {
            // check candidates
            foreach (var candidate in candidates.Keys.ToArray()) // <- we are going to change this collection
            {
                var checkedLength = candidates[candidate];
                if (value == pattern[checkedLength]) // <- here `checkedLength` is used in sense `nextPositionToCheck`
                {
                    // candidate has match next value
                    checkedLength += 1;
                    // check if we are done here
                    if (checkedLength == pattern.Length) return candidate; // <- exit point
                    candidates[candidate] = checkedLength;
                }
                else
                    // candidate has failed
                    candidates.Remove(candidate);
            }
            // check for new candidate
            if (value == pattern[0])
                candidates.Add(index, 1);
            index++;
        }
        // we did everything we could
        return -1;
    }
