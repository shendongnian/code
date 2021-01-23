    Dictionary<String, Func<object>> debugStrings = new Dictionary<String, Func<object>>();
    
    public void addVariable(String index, Func<object> getValue) {
      debugStrings.Add(index, obj);                        
    }
