    public static decimal IncomeTax(decimal income)
    {
        // Only positive income can be taxed
        if (income <= 0M) return 0M;
        // Initialize bracket limits and rate percentages
        int[] brackets = { 0, 9525, 38700, 82500, 157500,
                           200000, 500000, int.MaxValue };
        int[] rates = { 10, 12, 22, 24, 32, 35, 37 };
        // Start with zero tax
        decimal tax = 0M;
        // Loop over tax rates and corresponding brackets
        for (int i = 0; i < rates.Length; i++)
        {
            // Calculate amount of current bracket
            int currBracket = brackets[i + 1] - brackets[i];
            // If income is below lower bound, exit loop
            if (income < brackets[i]) break;
            // If income is between lower and upper bound,
            if (income < brackets[i + 1])
            {
                // adjust bracket length accordingly
                currBracket = income - brackets[i];
            }
            // Add tax for current bracket to accumulated tax
            tax += (rates[i] / 100M) * currBracket;
        }
        // Return result
        return tax;
    }
