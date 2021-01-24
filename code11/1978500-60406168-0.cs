    private static Dictionary<char, int> _romanMap = new Dictionary<char, int>
    {
       {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
    };
  
    public static int IsRoman(string text) {
      foreach (var c in text) 
          if (!_romanMap.ContainsKey(char))
              return 0;
       return 1 
     }
