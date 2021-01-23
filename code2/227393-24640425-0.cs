    public static int[] GetNumbersFromString(string str)
    {
       List<int> result = new List<int>();
       string[] numbers = Regex.Split(input, @"\D+");
       int i;
       foreach (string value in numbers)
       {
          if (int.TryParse(value, out i))
          {
             result.Add(i);
          }
       }
       return result.ToArray();
    }
