	        /// <summary>
        /// Get the keys from the input and return it in a `;` delimited string
        /// </summary>
        /// <param name="vals">Input list</param>
        /// <returns></returns>
        public static List<string> GetKeys(List<string> vals)
        {
            var keys = new List<string>();
            foreach (var grouping in vals)
            {
                var parameters = grouping.Split(' ');
                foreach (var parameter in parameters)
                {
                    var paramVals = parameter.Split(':');
                    var label = paramVals[0].Trim();
                    if (!string.IsNullOrEmpty(label) && !keys.Contains(label))
                    {
                        keys.Add(label);
                    }
                }
            }
            return keys;
        }
        /// <summary>
        /// Take all the keys and return all possible combinations of them
        /// </summary>
        /// <param name="list">List of keys</param>
        /// <returns></returns>
        public static List<string> GetCombination(List<string> list)
        {
            var combos = new List<string>();
            var comb = "";
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                var sep = "";
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        comb += sep + list[j];
                        sep = ";";
                    }
                }
                combos.Add(comb);
                comb = "";
            }
            return combos;
        }
        /// <summary>
        /// Return the combinations that have the largest values
        /// </summary>
        /// <param name="source">String list of input</param>
        /// <param name="combo">`;` delimited keys you're checking</param>
        /// <returns></returns>
        public static List<string> GetMaxOfCombo(List<string> source, string combo)
        {
            var comboKeys = combo.Split(';');
            var matchingCombos = source.Where(s => comboKeys.All(a => s.IndexOf(a) != -1) && s.Trim().Split(' ').Length == comboKeys.Count());
            // Return empty set if there were none
            if (!matchingCombos.Any())
            {
                return new List<string>();
            }
            var comboValues = matchingCombos.Select(mc => new
            {
                // Get the value sum of the individual keys
                value = mc.Split(' ').Where(w => !string.IsNullOrEmpty(w.Trim())).Sum(s => int.Parse(string.Concat(s.Where(c => char.IsDigit(c))))),
                label = mc
            });
            // Get the max value
            var max = comboValues.Max(m => m.value);
            // Get all that have the same max
            var maxCombos = comboValues.Where(f => f.value == max);
            if (!maxCombos.Any())
            {
                return new List<string>();
            }
            return maxCombos.Select(s => s.label).ToList();
        }
