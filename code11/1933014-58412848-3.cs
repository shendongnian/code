        public static string GetStringValue(animNames enumTarget)
        {
            var key = System.Enum.GetName(typeof(animNames), enumTarget);
            var nameEntry = _AnimNames.FirstOrDefault(x => x.Key == key);
            var nameValue = nameEntry.Value;
            return nameValue;
        }
