      using System.Linq;
      using System.Text.RegularExpressions;
      ...
      string pattern = 
        @"(?:\s+x(?<number>[0-9]+(\.[0-9]+)?)\s*=\s*)?(?<price>[0-9]+(\.[0-9]+)?)\s*$";
      var total = myListBox
        .Items
        .OfType<Object>()
        .Where(item => item != null)
        .Select(item => Regex.Match(item.ToString(), pattern))
        .Where(match => match.Success)
        .Select(match => new {
          number = string.IsNullOrEmpty(match.Groups["number"].Value)
            ? 1m  // if number is not specified we have 1 item
            : decimal.Parse(match.Groups["number"].Value),
          price = decimal.Parse(match.Groups["price"].Value)
        })
        .Sum(item => item.price * item.number);
