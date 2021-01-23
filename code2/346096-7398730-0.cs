    static string BaseConvert(string number, int fromBase, int toBase)
    {
        var digits = "0123456789abcdefghijklmnopqrstuvwxyz";
        var length = number.Length;
        var result = string.Empty;
        var nibbles = number.Select(c => digits.IndexOf(c)).ToList();
        int newlen;
        do {
            var value = 0;
            newlen = 0;
        
            for (var i = 0; i < length; ++i) {
                value = value * fromBase + nibbles[i];
                if (value >= toBase) {
                    if (newlen == nibbles.Count) {
                        nibbles.Add(0);
                    }
                    nibbles[newlen++] = value / toBase;
                    value %= toBase;
                }
                else if (newlen > 0) {
                    if (newlen == nibbles.Count) {
                        nibbles.Add(0);
                    }
                    nibbles[newlen++] = 0;
                }
            }
            length = newlen;
            result = digits[value] + result; //
        }
        while (newlen != 0);
        return result;
    }
