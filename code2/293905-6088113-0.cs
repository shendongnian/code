        string[] SplitStringInTwo(string input, char separator)
        {
            string[] results = new string[2];
            if (string.IsNullOrEmpty(input)) return results;
            int splitPos = input.IndexOf(separator);
            if (splitPos <= 0) return results;
            results[0] = input.Substring(0, splitPos);
            if (splitPos<input.Length)
                results[1] = input.Substring(splitPos + 1);
            return results;
        }
