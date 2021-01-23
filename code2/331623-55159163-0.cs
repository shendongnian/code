    public class RomanNumerals
    {
        private List<Tuple<char, ushort, char?[]>> _validNumerals = new List<Tuple<char, ushort, char?[]>>()
        {
            new Tuple<char, ushort, char?[]>('I', 1, new char? [] {'V', 'X'}),
            new Tuple<char, ushort, char?[]>('V', 5, null),
            new Tuple<char, ushort, char?[]>('X', 10, new char?[] {'L', 'C'}),
            new Tuple<char, ushort, char?[]>('L', 50, null),
            new Tuple<char, ushort, char?[]>('C', 100, new char? [] {'D', 'M'}),
            new Tuple<char, ushort, char?[]>('D', 500, null),
            new Tuple<char, ushort, char?[]>('M', 1000, new char? [] {null, null})
        };
        public int TranslateRomanNumeral(string input)
        {
            var inputList = input?.ToUpper().ToList();
            if (inputList == null || inputList.Any(x => _validNumerals.Select(t => t.Item1).Contains(x) == false))
            {
                throw new ArgumentException();
            }
            char? valForSubtraction = null;
            int result = 0;
            bool noAdding = false;
            int equalSum = 0;
            for (int i = 0; i < inputList.Count; i++)
            {
                var currentNumeral = _validNumerals.FirstOrDefault(s => s.Item1 == inputList[i]);
                var nextNumeral = i < inputList.Count - 1 ? _validNumerals.FirstOrDefault(s => s.Item1 == inputList[i + 1]) : null;
                bool currentIsDecimalPower = currentNumeral?.Item3?.Any() ?? false;
                if (nextNumeral != null)
                {
                    // Syntax and Semantics checks
                    if ((currentNumeral.Item2 < nextNumeral.Item2) && (currentIsDecimalPower == false || currentNumeral.Item3.Any(s => s == nextNumeral.Item1) == false) ||
                        (currentNumeral.Item2 == nextNumeral.Item2) && (currentIsDecimalPower == false || nextNumeral.Item1 == valForSubtraction) ||
                        (currentIsDecimalPower && result > 0 &&  ((nextNumeral.Item2 -currentNumeral.Item2) > result )) ||
                        (currentNumeral.Item2 > nextNumeral.Item2) && (nextNumeral.Item1 == valForSubtraction)
                        
                        )
                    {
                        throw new ArgumentException();
                    }
                    if (currentNumeral.Item2 == nextNumeral.Item2)
                    {
                        equalSum += equalSum == 0 ? currentNumeral.Item2 + nextNumeral.Item2 : nextNumeral.Item2;
                        int? smallest = null;
                        var list = _validNumerals.Where(p => _validNumerals.FirstOrDefault(s => s.Item1 == currentNumeral.Item1).Item3.Any(s2 => s2 != null && s2 == p.Item1)).ToList();
                        if (list.Any())
                        {
                            smallest = list.Select(s3 => s3.Item2).ToList().Min();
                        }
                        // Another Semantics check
                        if (currentNumeral.Item3 != null && equalSum >= (smallest - currentNumeral.Item2))
                        {
                            throw new ArgumentException();
                        }
                        result += noAdding ? 0 : currentNumeral.Item2 + nextNumeral.Item2;
                        noAdding = !noAdding;
                        valForSubtraction = null;
                    }
                    else
                    if (currentNumeral.Item2 < nextNumeral.Item2)
                    {
                        equalSum = 0;
                        result += nextNumeral.Item2 - currentNumeral.Item2;
                        valForSubtraction = currentNumeral.Item1;
                        noAdding = true;
                    }
                    else 
                    if (currentNumeral.Item2 > nextNumeral.Item2)
                    {
                        equalSum = 0;
                        result += noAdding ? 0 : currentNumeral.Item2;
                        noAdding = false;
                        valForSubtraction = null;
                    }
                }
                else
                {
                    result += noAdding ? 0 : currentNumeral.Item2;
                }
            }
            return result;
        }
    }
