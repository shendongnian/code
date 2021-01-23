    public void RunTest()         
    {            
     if (baseList.Count > 0)
     {
       Type ctorParam = typeof(List<>).MakeGenericType(baseList[0].GetType());
       object instance = typeof(CallMe).GetConstructor(new Type[] { ctorParam })
                                .Invoke(new object[] { baseList });   
     }
    } 
