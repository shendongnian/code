    string holder = "Element {0} = {1}";
    string s0 = "111 222 XYZ";
    ArrayList arr = new ArrayList();
    string s1 = Regex.Replace(s0, @"\d+",
      m => string.Format(holder, arr.Add(m.Value), m.Value)
    );
    Console.WriteLine(s1);
    foreach (string s in arr)
    {
      Console.WriteLine(s);
    }
