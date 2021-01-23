    public Expression<Func<Item, ItemProjection>> TweakValue()
    {
        return item => new ItemProjection 
                       {
                           Value1 = item.Value1,
                           Value2 = item.Value2 + 0 // or something else L2E can understand...
                       }; 
    }
