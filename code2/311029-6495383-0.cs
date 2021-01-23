    private int GetDatePart(int part)
    {
    	long internalTicks = this.InternalTicks;
    	int num1 = (int)internalTicks / 864000000000L;
    	int num2 = num1 / 146097;
    	num1 = num1 - (num2 * 146097);
    	int num3 = num1 / 36524;
    	if (num3 == 4)
    	{
    		num3 = 3;
    	}
    	num1 = num1 - (num3 * 36524);
    	int num4 = num1 / 1461;
    	num1 = num1 - (num4 * 1461);
    	int num5 = num1 / 365;
    	if (num5 == 4)
    	{
    		num5 = 3;
    	}
    	if (part == 0)
    	{
    		return ((((num2 * 400) + (num3 * 100)) + (num4 * 4)) + num5) + 1;
    	}
    	num1 = num1 - (num5 * 365);
    	if (part == 1)
    	{
    		return num1 + 1;
    	}
    	bool flag = num5 == 3 && ((num4 == 24 && num3 == 3) || !(num4 == 24));
    	int[] daysToMonth366 = DateTime.DaysToMonth366;
    	int num6 = num1 >> 6;
    	while (num1 >= daysToMonth366[num6])
    	{
    		num6++;
    	}
    	if (part == 2)
    	{
    		return num6;
    	}
    	return (num1 - daysToMonth366[(num6 - 1)]) + 1;
    }
    
    
    
    internal long InternalTicks
    {
    	get
    	{
    		return this.dateData & 4611686018427387903L;
    	}
    }
    
    
    
    public int Day
    {
    	get
    	{
    		return this.GetDatePart(3);
    	}
    }
