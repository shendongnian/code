    /// <summary>
    /// Rounds the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="decimals">The decimals.</param>
    /// <returns></returns>
    public static decimal RoundNew (this decimal value, int decimals)
    {
        return Math.Round(value, decimals);
    }
    decimal newAmount = decimal.Parse("3.33333333333434343434");
    this.rtbAmount.Text = newAmount.RoundNew(3).ToString();
