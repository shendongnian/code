    public static bool AllEqual(bool[] values)
    {
        bool andTerm = true;
        bool orTerm = false;
        foreach (bool v in values)
        {
            andResult &= v;
            orResult |= v;
        }
        return andTerm || !orTerm;
    }
