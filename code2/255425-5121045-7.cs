    public int Compare(string first, string second)
    {
        // For simplicity, let's assume neither is null :)
        int firstNumber, secondNumber;
        bool firstIsNumber = int.TryParse(first, out firstNumber);
        bool secondIsNumber = int.TryParse(second, out secondNumber);
        if (firstIsNumber)
        {
            // If they're both numbers, compare them; otherwise first comes first
            return secondIsNumber ? firstNumber.CompareTo(secondNumber) : -1;
        }
        // If second is a number, that should come first; otherwise compare
        // as strings
        return secondIsNumber ? 1 : first.CompareTo(second);
    }
