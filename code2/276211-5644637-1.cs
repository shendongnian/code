        public static IEnumerable<String> SplitToParts(this String forSplit, Int32 splitLength) 
        {   
            for (var i = 0; i < forSplit.Length; i += splitLength)
              yield return forSplit.Substring(i, Math.Min(splitLength, forSplit.Length - i));
        }
    string s ="1234123412341234";
