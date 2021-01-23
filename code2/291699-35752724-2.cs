    public static class Match
    {
        public static PatternMatch<T, R> With<T, R>(T value)
        {
            return new PatternMatch<T, R>(value);
        }
        public struct PatternMatch<T, R>
        {
            private readonly T _value;
            private R _result;
            private bool _matched;
            public PatternMatch(T value)
            {
                _value = value;
                _matched = false;
                _result = default(R);
            }
            public PatternMatch<T, R> When(Func<T, bool> condition, Func<R> action)
            {
                if (!_matched && condition(_value))
                {
                    _result = action();
                    _matched = true;
                }
                return this;
            }
            public PatternMatch<T, R> When<C>(Func<C, R> action)
            {
                if (!_matched && _value is C)
                {
                    _result = action((C)(object)_value);
                    _matched = true;
                }
                return this;
            }
            public PatternMatch<T, R> When<C>(C value, Func<R> action)
            {
                if (!_matched && value.Equals(_value))
                {
                    _result = action();
                    _matched = true;
                }
                return this;
            }
            public R Result => _result;
            public R Default(Func<R> action)
            {
                return !_matched ? action() : _result;
            }
        }
    }
