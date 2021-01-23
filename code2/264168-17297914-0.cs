     public static string TruncatString(string input, int maxLength)
            {
                if (input.Length < maxLength) return input;
                return input.Substring(0, maxLength - 3) + "...";
            }
