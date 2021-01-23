    public class SumBelowAttribute : ValidationAttribute
    {
        private readonly int _max;
        public SumBelowAttribute(int max)
        {
            _max = max;
        }
        public override bool IsValid(object value)
        {
            var b = value as B_Validation;
            if (b != null)
            {
                return b.first + b.second + b.third < _max;
            }
            return base.IsValid(value);
        }
    }
