    private static IEnumerable<string> MyObjectToTree(IEnumerable<MyObject> roots, int shift = 6) {
      if (null == roots)
        yield break;
      foreach (var root in roots) {
        HashSet<MyObject> completed = new HashSet<MyObject>();
        Stack<Tuple<int, MyObject>> agenda = new Stack<Tuple<int, MyObject>>();
        agenda.Push(Tuple.Create(0, root));
        while (agenda.Any()) {
          Tuple<int, MyObject> item = agenda.Pop();
          if (!completed.Add(item.Item2))
            continue;
          List<MyObject> children = item.Item2?.depandantObj ?? new List<MyObject>();
          children.Reverse();
          yield return $"{new string(' ', shift * item.Item1)}{item.Item2?.name}{(children.Any() ? ":" : "")}";
          foreach (var child in children)
            agenda.Push(Tuple.Create(item.Item1 + 1, child));
        }
      }
    }
