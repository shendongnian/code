            // Check for empty string.
            if (string.IsNullOrEmpty(UpperCase))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(UpperCase[0]) + UpperCase.Substring(1);
        }
