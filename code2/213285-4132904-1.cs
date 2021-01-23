    public static class MoneyExtensions {
        public static Money Sum(this IEnumerable<Money> source) {
            Money sum = source.First();
            foreach(var item in source.Skip(1)) sum += item;
            return sum;
        }
    }
