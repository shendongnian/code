    PropertyInfo[] pInfos = typeof(MyClassType).GetProperties(); //Assuming MyClass is of Type MyClassType
    Foreach (MyClassAssigments aData In MyData)
    {
       PropertyInfo eachPInfo in pInfos.Where(W => W.Name == aData.PropertiesToAssign)).SingleOrDefault(); 
       If (eachPInfo != null)
       {
          eachPInfo.SetValue(MyClass, doingsomething(aData.ClassInfoStringIPassedToFunctionInFirstExample), null);
       }
    }
