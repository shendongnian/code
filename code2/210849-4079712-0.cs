    void FillDictionary(Dictionary<string, Node> dictionary, Node rootNode)
    {
      if (dictionary.ContainsKey(rootNode.Code)
        return;
      dictionary.Add(rootNode.Code, rootNode);
      foreach (Node child in rootNode.Children)
        FillDictionary(dictionary, child)
    }  
