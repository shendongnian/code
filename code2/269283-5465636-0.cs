    static IList FindList(string name)
    {
      if (name == "l1") { return l1; }
      else if (name == "l2") { return l2; }
      else throw Exception("List " + name + " not found.");
    }
