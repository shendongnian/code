    public IEnumerable<IEnumerable<T>> void Test<T>()
    {
      // Create a top IEnumeranble instance you should specify list element type
      var result = new List<IEnumerable<T>>();
      
      // Add an internal IEnumerable<T>
      result.Add(new List<T>());
    
      return result;
    }
