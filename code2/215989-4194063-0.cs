    Type objTyp = typeof(MyObject); //HardCoded TypeName for demo purpose
    var IListRef = typeof (List<>);
    Type[] IListParam = {objTyp};          
    object Result = Activator.CreateInstance(IListRef.MakeGenericType(IListParam));
    
    MyObject objTemp = new MyObject(); 
    Result.GetType().GetMethod("Add").Invoke(Result, new[] {objTemp });
