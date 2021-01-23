    private bool isequal(object a, object b)
    {
    int c,d;
            if (int.TryParse(a.ToString(), out c) && int.TryParse(b.ToString(), out d))
            {
                if (c == d)
                    return true;
            }
    if (a != null)
        return a.Equals(b);
    if (b != null)
        return b.Equals(a);
    //if (a == null && b == null)
        return true;
    }
