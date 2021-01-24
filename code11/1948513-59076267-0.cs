    public void GetPayment()
    {
        double firstCalculation = (loan * rate / 100);  
        double secondCalculation = (1 - 1 / Math.Pow(1 + rate / 100, period));
        double payment = firstCalculation / secondCalculation; // <-- right here.
    }
