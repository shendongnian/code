        private static List<int> ParseDbInt(string databaseValue)
        {
            // Remove brackets
            var numStr = databaseValue.Replace("[", String.Empty);
            numStr     = numStr.Replace("]", String.Empty);
            // Now split that string into a string array using String.Split
            var numbers = numStr.Split(new char[] { ',' });
            // Split the comma-seperated numbers into a List using LINQ "Select" keyword
            return new List<int>(numbers.Select(s => int.Parse(s)));
        }
