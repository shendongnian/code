    class ActionOption<T1, T2, T3, T4, T5, T6> : Option {
        Action<T1, T2, T3, T4, T5, T6> action;
        public ActionOption (string prototype, string description,
                 Action<T1, T2, T3, T4, T5, T6> action)
            : base (prototype, description, 6)
        {
            this.action = action;
        }
        protected override void OnParseComplete (OptionContext c)
        {
            action (
                    Parse<T1>(c.OptionValues [0], c)),
                    Parse<T2>(c.OptionValues [1], c)),
                    Parse<T3>(c.OptionValues [2], c)),
                    Parse<T4>(c.OptionValues [3], c)),
                    Parse<T5>(c.OptionValues [4], c)),
                    Parse<T6>(c.OptionValues [5], c)));
        }
    }
