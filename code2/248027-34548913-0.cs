    public static string DeleteLines(
         string stringToRemoveLinesFrom, 
         int numberOfLinesToRemove, 
         bool startFromBottom = false) {
                string toReturn = "";
                string[] allLines = stringToRemoveLinesFrom.Split(
                        separator: Environment.NewLine.ToCharArray(),
                        options: StringSplitOptions.RemoveEmptyEntries);
                if (startFromBottom)
                    toReturn = String.Join(Environment.NewLine, allLines.Take(allLines.Length - numberOfLinesToRemove));
                else
                    toReturn = String.Join(Environment.NewLine, allLines.Skip(numberOfLinesToRemove));
                return toReturn;
    }
