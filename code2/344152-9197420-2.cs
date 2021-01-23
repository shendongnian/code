    public string RemoveControlCharacters(Stream input)
    {
        return
            _ReadCharacters(input)
            .Where( character => !Char.IsControl(character))
            .Aggregate( new StringBuilder(), ( builder, character ) => builder.Append( character ) )
            .ToString();
    }
