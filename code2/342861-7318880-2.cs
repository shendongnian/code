    public int GetRuleWeight(IRule item)
    {
       //build a table of type weights (this could be made static)
       Dictionary<Type, int> typeWeights = new Dictionary<Type, int>();
       typeWeights.Add(typeof(AddRule), 1);
       typeWeights.Add(typeof(EditRule), 2);
       typeWeights.Add(typeof(DeleteRule), 3);
      Type itemType = item.GetType();
      
      if (!typeWeights.ContainsKey(itemType))
         throw new Exception("invalid type");
      return typeWeights[itemType];
    }
    allRules = allRules.OrderBy(item => GetRuleWeight(item)).ToList();
