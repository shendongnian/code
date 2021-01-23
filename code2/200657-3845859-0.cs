    protected Dictionary<string, double> CDCost()
        {
            Dictionary<string,double> values = new Dictionary<string,double>();
            double monthlyAmount;
            double annualAmount;
            double amount;
            double users = Convert.ToDouble(txtCD.Text);
    
            if (users > 0 && users < 100)
        {
            amount = users * 14.95;
            values["monthlyAmount"] = amount;
            values["annualAmount"] = monthlyAmount * 12;
            return values
        }
}
