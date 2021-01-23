    public static string[] SplitCSV(string input)
    {
      Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
      List<string> list = new List<string>();
      string curr = null;
      foreach (Match match in csvSplit.Matches(input))
      {        
        curr = match.Value;
        if (0 == curr.Length)
        {
          list.Add("");
        }
        list.Add(curr.TrimStart(','));
      }
      return list.ToArray();
    }
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine(SplitCSV("111,222,\"33,44,55\",666,\"77,88\",\"99\""));
    }
