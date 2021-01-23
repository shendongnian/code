    string binarystring = String.Concat(
      hexstring.Select(c => {
        int n = Convert.ToInt32(c.ToString(), 32);
        string s = String.Empty;
        for (int i = 0; i < 4; i++) {
          s = (n % 2).ToString() + s;
          n /= 2;
        }
        return s;
      })
      .ToArray()
    );
