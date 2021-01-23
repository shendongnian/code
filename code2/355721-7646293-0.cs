    private List<string> Combine(params string[][] arrays)
    {
        if (arrays.Length == 1)
        {
            // The trivial case - exit.
            return new List<string>(arrays[0]);
        }
        IEnumerable<string> last = arrays[arrays.Length - 1];
        // Build from the last array, progress forward
        for (int i = arrays.Length - 2; i >= 0; i--)
        {
            var buffer = new List<string>();
            var current = arrays[i];
            foreach (var head in current)
            {
                foreach (var tail in last)
                {
                    // Concatenate with the desired space.
                    buffer.Add(head + " " + tail);
                }
            }
            last = buffer;
        }
        return (List<string>)last;
    }
