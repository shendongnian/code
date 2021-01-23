    private char _nextChar;
    private IEnumerable<char> getAlphabet()
    {
        yield return 'A';
        yield return 'B';
        yield return 'C';
    }
    
    public void sortAlphabet()
    {
        using (var enumerator = getAlphabet().GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                char alpha = enumerator.Current;
                switch (alpha)
                {
                    case 'A':
                        if (enumerator.MoveNext())
                        {
                            _nextChar = enumerator.Currrent;
                        }
                        else
                        {
                            // You decide what to do in this case.
                        }
                        break;
                    case 'B':
                        // etc.
                        break;
                }
            }
        }
    }
