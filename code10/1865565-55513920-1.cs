    string input = "aSd2&5s@1";
    var matched = Regex.Matches(input, @"\d+");
    var builder = new StringBuilder();
    foreach (Match match in matched)
    {
         string stingToDuplicate = input.Split(Char.Parse(match.Value))[0];
         input = input.Replace(stingToDuplicate, String.Empty).Replace(match.Value, String.Empty);
          for (int i = 0; i < Convert.ToInt32(match.Value); i++)
          {
                      builder.Append(stingToDuplicate.ToUpper());
          }
     }
