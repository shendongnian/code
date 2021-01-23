    public Dictionary<string, SomeObject> SortByProp<TProp>(Dictionary<string, SomeObject> dict, Expression<SomeObject,TProp> orderPredicate) 
    {
       return dict.OrderBy(orderPredicate);
    }
    // Usage: 
    SortByProp(apples, x => x.AppleColor);
    SortByProp(oranges, x => x.OrangeType);
        
