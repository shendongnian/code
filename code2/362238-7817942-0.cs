    List<string> newList = new List<string>();
    
                Regex regex = new Regex(@"\w(?:(?!,| ).)*");
                string str = "Apple ,Banana, , , , Mango ,Strawberry , ";
                MatchCollection matches = regex.Matches(str);
                foreach (Match match in matches)
                {
                    newList.Add(match.Value);
                }
