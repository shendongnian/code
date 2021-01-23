    public void RunTest()
    { 
        // it seems like you would want to run the following using reflection...
        // var myBaseList = this.baseList.OfType<this.baseList[0].GetType()>().ToList();
        
        Type[] genericTypeArray = new Type[] { this.baseList[0].GetType() };
        // call OfType to get IEnumerable<this.baseList[0].GetType()>
        MethodInfo ofTypeMethodInfo = typeof(Enumerable).GetMethods().Where(d => d.Name == "OfType").First();
        ofTypeMethodInfo = ofTypeMethodInfo.MakeGenericMethod(genericTypeArray);
        object myBaseEnumerable = ofTypeMethodInfo.Invoke(null, new object[] { this.baseList });
        
        // call ToList to get List<this.baseList[0].GetType()>
        MethodInfo toListMethodInfo = typeof(Enumerable).GetMethods().Where(d => d.Name == "ToList").First();
        toListMethodInfo = toListMethodInfo.MakeGenericMethod(genericTypeArray);
        object myBaseList = toListMethodInfo.Invoke(null, new object[] { myBaseEnumerable });
        Object o = Activator.CreateInstance(typeof(CallMe), new object[] { myBaseList }); 
    }
