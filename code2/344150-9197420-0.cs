    public string RemoveControlCharacters(string input)
    {
        return
            input.Where(character => !char.IsControl(character))
            .Aggregate(new StringBuilder(), (builder, character) => builder.Append(character))
            .ToString();
    }
