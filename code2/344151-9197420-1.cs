    public IEnumerable<char> _ReadCharacters(Stream input)
    {
        using(var reader = new StreamReader(input))
        {
            while(!reader.EndOfStream)
            {
                foreach(var character in reader.ReadLine())
                {
                    yield return character;
                }
            }
        }
    }
