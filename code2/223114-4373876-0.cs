     class AlphaNumericComparer : IComparer<string>
            {
                public int Compare(string x, string y)
                {
                    // if both values are integers then do int comparision
                    int xValue, yValue;
                    if (int.TryParse(x, out xValue) && int.TryParse(y, out yValue))
                        return xValue.CompareTo(yValue);
    
                    return x.CompareTo(y); // else do string comparison
                }
            }
