    private static bool? Assign(bool b, bool c)
        {
            if (b || c)
            {
                return b;
            }
            else return null;
        }
    ...
    a = Assign (b,c)
