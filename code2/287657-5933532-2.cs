    // obviously, if indices.Length is zero,
    // you won't do anything
    List<string> results = new List<string>();
    if (indices.Count > 0)
    {
        // add the length of the string to indices
        // as the "dummy" split position, because we
        // want last split to go till the end
        indices.Add(input.Length + 1);
        // split string between each pair of indices
        for (int i = 0; i < indices.Count-1; i++)
        {
            // get bounding indices
            int idx = indices[i];
            int nextIdx = indices[i+1];
            // split the string
            string partial = input.Substring(idx, nextIdx - idx - 1).Trim();
            // add to results
            results.Add(partial);
        }
    }
