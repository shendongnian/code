        static IEnumerable<List<int>> GetChange(int target, IQueryable<int> coins)
        {
            var availableCoins = from c in coins where c <= target select c;
            if (!availableCoins.Any())
            {
                yield return new List<int>();
            }
            else
            {
                foreach (var thisCoin in availableCoins)
                {
                    foreach (var result in GetChange(target - thisCoin, from c in availableCoins where c <= thisCoin select c))
                    {
                        result.Add(thisCoin);
                        yield return result;
                    }
                }
            }
        }
