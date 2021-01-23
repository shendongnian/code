    public int IRuleComparer(IRule first, IRule second)
    {
      //build a table of type weights (this could be made static)
      Dictionary<Type, int> typeWeights = new Dictionary<Type, int>();
      typeWeights.Add(typeof(AddRule), 1);
      typeWeights.Add(typeof(EditRule), 2);
      typeWeights.Add(typeof(DeleteRule), 3);
      
      //get the types of the arguments
      Type firstType = first.GetType();
      Type secondType = second.GetType();
      
      //are the types valid?
      if (!typeWeights.ContainsKey(firstType))
         throw new Exception("invalid first type");
      if (!typeWeights.ContainsKey(secondType))
         throw new Exception("invalid second type");
      //compare the weights of the types
      return typeWeights[firstType].CompareTo(typeWeights[secondType]);
    }
