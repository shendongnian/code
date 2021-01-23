    public static class RangeFinder
    {
        public static void FindRange(IEnumerable<string> strings,
            out string startRange, out string endRange)
        {
            using (var e = strings.GetEnumerator()) {
                if (!e.MoveNext())
                    throw new ArgumentException("strings", "No elements.");
                if (e.Current == null)
                    throw new ArgumentException("strings",
                        "Null element encountered at index 0.");
                var template = e.Current;
                // If an element in here is true, it means that index differs.
                var matchMatrix = new bool[template.Length];
                int index = 1;
                string last = null;
                while (e.MoveNext()) {
                    if (e.Current == null)
                        throw new ArgumentException("strings",
                            "Null element encountered at index " + index + ".");
                    last = e.Current;
                    if (last.Length != template.Length)
                        throw new ArgumentException("strings",
                            "Element at index " + index + " has incorrect length.");
                    for (int i = 0; i < template.Length; i++)
                        if (last[i] != template[i])
                            matchMatrix[i] = true;
                }
                // Verify the matrix:
                // * There must be at least one true value.
                // * All true values must be consecutive.
                int start = -1;
                int end = -1;
                for (int i = 0; i < matchMatrix.Length; i++) {
                    if (matchMatrix[i]) {
                        if (end != -1)
                            throw new ArgumentException("strings",
                                "Inconsistent match matrix; no usable pattern discovered.");
                        if (start == -1)
                            start = i;
                    } else {
                        if (start != -1 && end == -1)
                            end = i;
                    }
                }
                if (start == -1)
                    throw new ArgumentException("strings",
                        "Strings did not vary; no usable pattern discovered.");
                if (end == -1)
                    end = matchMatrix.Length;
                startRange = template.Substring(start, end - start);
                endRange = last.Substring(start, end - start);
            }
        }
    }
