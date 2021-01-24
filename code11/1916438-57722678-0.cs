    class FactorizedInteger {
        private Dictionary<long, long> _factors = new Dictionary<long, long>();
        public FactorizedInteger(long radix, long exponent) {
            _factors[radix] = exponent;
        }
        public void Add(FactorizedInteger other) {
            foreach(var factor in other._factors) {
                if (_factors.ContainsKey(factor.Key)) {
                    _factors[factor.Key] += factor.Value;
                } else {
                    _factors[factor.Key] = factor.Value;
                }
            }
        }
        public override string ToString() {
            return "(" + String.Join(" + ", _factors.Select(p => $"{p.Key}^{p.Value}")) + ")";
        }
    }
