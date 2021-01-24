    public static bool Execute(int num)
    {
        if ((num >> 5) != 0) // check if bits 6, 7, 8 are zero
        {
            // do something
        }
        else if ((num & 0x0E) != 0) // check if bits 2, 3, 4 are zero
        {
            // do something
        }
        else if ((num & 1) != 1) // check if bit 1 is 1
        {
            // do something
        }
        else
        {
            return false; // nothing has been done
        }
        return true; // something has been done
    }
