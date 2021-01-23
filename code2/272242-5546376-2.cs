    public static int discount(string []cardStatus, int []pDiscount, string custStatus)
    {
        for(int i = 0; i < Math.Min(cardStatus.Length, pDiscount.Length); i++)
        {
            if (string.Equals(custStatus, cardStatus[i]))
            {
                return pDiscount[i];
            }
        }
        return -1;
    }
