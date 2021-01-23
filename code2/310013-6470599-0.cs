    void MyFunc(IEnumerable parm)
    {
        if (parm == null)
            return;
        foreach (object nextMember in parm)
        {
            if (nextMember is string)
            // ...
        }
    }
