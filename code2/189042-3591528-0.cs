    enum State
    {
        Scan,
        SaveAndExit
    };
    public void SortAlphabet()
    {
        State state = State.Scan; // initialize
        foreach(char c in getAlphabet())
        {
            switch (state):
            {
                case State.Scan:
                    if (c == 'A' ||
                        c == 'B')
                        state = State.SaveAndExit;
                    break;
                case State.SaveAndExit:
                    return (c);
                    break;
            }
        }
    }
