    void FillDictionary(Dictionary<string, Node> dictionary, Node node)
    {
      if (dictionary.ContainsKey(node.Code))
        return;
      dictionary.Add(node.Code, node);
      foreach (Node child in node.Children)
        FillDictionary(dictionary, child)
    }  
