    using(TextReader tr = new StreamReader(someFile))//no way for compiler to know what this will contain
    {
      string a = tr.ReadLine();
      string b = tr.ReadLine();
      string c = tr.ReadLine();
      string d = tr.ReadLine();
      string e = tr.ReadLine();
      string f = tr.ReadLine();
      string first = a;
      first += b;
      first += c;
      string second = d + e + f;
    }
