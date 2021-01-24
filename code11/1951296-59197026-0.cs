        public string IncrementStringId(string input)
    {
        // The RexEx pattern is looking at the very end of the string for any number encased in paranthesis
        string pattern = @"\(\d*\)$";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(input);
        if (match.Success)
            if (int.TryParse(match.Value.Replace(@"(", "").Replace(@")", ""), out int index))
                //if pattern in found parse the number detected and increment it by 1
                return Regex.Replace(input, pattern, "(" + ++index + ")");
        // In case the pattern is not detected add a (1) to the end of the string
        return input + "(1)";
    }
