    public string GetValue() 
    {
      using (var valueStore = new WeightedValueStore<string>()) 
      {
        valueStore.AddValue(30, "A");
        valueStore.AddValue(14, "B");
        valueStore.AddValue(31, "C");
        valueStore.AddValue(25, "D");
        return valueStore.GetValue();
      }
    }
