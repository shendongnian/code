    public void RunTest()         
    {            
      if (baseList.Count > 0)
      {
         Type ctorParam = baseList[0].GetType().MakeArrayType();
         object instance = typeof(CallMe).GetConstructor(new Type[] { ctorParam })
                                .Invoke(new object[] { baseList });   
      }
    } 
