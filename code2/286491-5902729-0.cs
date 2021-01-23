    static decimal F(int i)
    {
        // Receives the call number
        // To avoid so error
        if (i > 60)
        {
            // Stop after 60 calls
            return i;
        }
        else
        {
            // Return the running total with the new fraction added
            return 1 + (i / (1 + (2.0m * i))) * F(i + 1);
        }
    }
