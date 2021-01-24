    public static string ConvertMoneyIntoCoins(double money)
        {
            int cents = (int)(Math.Round(money, 2) * 100);
            var coins = new[] {
                                new { Name = "Quarters", Value = 25 }, new { Name = "Dimes", Value = 10 },
                                new { Name = "Nickels", Value = 5 }, new { Name = "Pennies", Value = 1 } 
                             };
            var changes = coins.Select(coin => new { Amt = Math.DivRem(cents, coin.Value, out cents), Coin = coin }).Where(x => x.Amt != 0).ToList();
            var strBld = new StringBuilder();
            foreach (var change in changes)
            {
                strBld.Append(change.Amt + " " + change.Coin.Name + ", ");
            }
            return strBld.ToString();
        }
