      int? number = html.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(l =>
        {
          l = l.Trim();
          if (l.Length == 1 && int.TryParse(l, out int num))
            return (int?)num;
          return null;
        }).FirstOrDefault(n => n != null);
      Console.WriteLine(number);
