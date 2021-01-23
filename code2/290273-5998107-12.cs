    long CreateValue(byte[] values)
    {
        // probably should check here to ensure that values is 10 bytes long.
        long val = 0;
        foreach (var b in values)
        {
            // do error check. If b > 15, then this is going to fail.
            val = (val << 5) | b;
        }
        return val;
    }
