    static string GetBinary(string number, bool invert)
    {
        // use unsigned ints to avoid negative number problems
        uint decNum = UInt32.Parse(number);
        if (invert) decNum = ~decNum;
        string binRep = String.Empty;
        uint digi = 0;
        do
        {
            digi = decNum % 2;
            binRep = digi.ToString() + binRep;
            decNum = decNum / 2;
        } while (decNum >= 1);
        return binRep;
    }
