    public static int GetQuarter(DateTime date)
        {
            int[] quarters = new int[] { 4,4,4,1,1,1,2,2,2,3,3,3 };
            return quarters[date.Month-1];
        }
