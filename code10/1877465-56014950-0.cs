        // DISCLAIMER: draft code only. Review and test before using.
        public class RangeQuantity : Quantity
        {
            private readonly int min;
            private readonly int maxInclusive;
            public RangeQuantity(int min, int maxInclusive) {
                this.min = min;
                this.maxInclusive = maxInclusive;
            }
            public override string Describe(string singularNoun, string pluralNoun) => 
                $"between {min} and {maxInclusive} (inclusive)";
            public override bool Matches<T>(IEnumerable<T> items) {
                var count = items.Count();
                return count >= min && count <= maxInclusive;
            }
            public override bool RequiresMoreThan<T>(IEnumerable<T> items) => items.Count() < min;
        }
