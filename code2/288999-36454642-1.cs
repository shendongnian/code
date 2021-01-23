        public TwiMLResult Show(string digits)
        {
            var selectedOption = digits;
            var optionActions = new Dictionary<string, Func<TwiMLResult>>()
            {
                {"1", ReturnInstructions},
                {"2", Planets}
            };
            return optionActions.ContainsKey(selectedOption) ?
                optionActions[selectedOption]() :
                RedirectWelcome();
        }
