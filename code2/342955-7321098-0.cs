    if (!dictionary.TryGetValue(word, out int count))
    {
        dictionary.Add(word, 1);
    }
    else
    {
        dictionary[word] += 1;
    }
