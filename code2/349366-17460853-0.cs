    IEnumerable<string> collection = Model.Results;
    using (var enumerator = .GetEnumerator())
    {
      bool flag;
      enumerator.MoveNext();
      string current;
      do
      {
        current = enumerator.Current;
        Console.Write(current);
        flag = enumerator.MoveNext();
        //!flag = last item
        Console.Write(flag ? ", " : ".");                  
        
      } while (flag);
    }
