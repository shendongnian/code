    public double SumOverStatus(TStatus status)
    {
        double sum = 0;
        foreach (var fromStatus in LoanStatusTypes)
        {
            int statusKey = GetKeyValue(fromStatus);
            int i = 0;
            while (i < MonthsSinceEventCount)
            {
                sum += VectorDictionary[statusKey, i];
                i++;
            }
        }
        return sum;
    }
