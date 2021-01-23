        public string DoSomething(string option)
        {
            return Helper.DoSomething(
                  (Options) Enum.Parse(typeof(Options), option)
                );
        }
