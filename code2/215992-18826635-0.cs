    Type objTyp = typeof(MyObject); //HardCoded TypeName for demo purpose
    var IListRef = typeof (List<>);
    Type[] IListParam = {objTyp};          
    IList Result = (IList)IListRef.MakeGenericType(IListParam);
    MyObject objTemp = new MyObject(); 
    Result.Add(objTemp);
