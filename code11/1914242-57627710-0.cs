public Dictionary<char, int> CharacterCount(string text)
{
    Dictionary<char, int> frequency = new Dictionary<char, int>();
    for (int i = 0; i < text.Length; i++)
    {
        char character = text[i];
        // ignore everything except letters or digits
        if (!char.IsLetterOrDigit(character)) continue;
        // this will seperate á into a and an accent character, and convert
        // everything to upper case
        var decomposed = character
            .ToString()
            .ToUpper()
            .Normalize(NormalizationForm.FormD);
        // take the first character so we get just a from á
        character = decomposed.First();
        // increment frequencies
        int count;
        if (frequency.TryGetValue(character, out count) == false)
            frequency.Add(character, 0);
        frequency[character] = ++count;
    }
            
    return frequency;
}
