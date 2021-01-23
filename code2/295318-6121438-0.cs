    Dictionary<nodeTypes, Action<Container, ZForm, int, bool>> generateActions = new Dictionary<nodeTypes, Action<Container, ZForm, int, bool>>
    { 
      {nodeTypes.SelectListValue, GenerateSubNode<SelectListValue> }, // not sure about the generic part here..
      {nodeTypes.MultiSelectListValue, GenerateSubNode<MultiSelectListValue> },
      // .. so on
    }
