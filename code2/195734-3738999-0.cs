    public string getMoneyCssClass(string amount)
    {
        if (!string.IsNullOrEmpty(amount))
        {
            double val = double.Parse(amount);
            if (val < 0)
                return "NegativeMoneyTextCss";
        }
        return return "PositiveMoneyTextCss";
    }
