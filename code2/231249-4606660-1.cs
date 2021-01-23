    class Test{ public int X {get;set;} }
 
    //...elsewhere
	var xPropSetter = typeof(Test)
        .GetProperty("X",BindingFlags.Instance|BindingFlags.Public)
        .GetSetMethod();
	var newValPar=Expression.Parameter(typeof(int));
	var objectPar=Expression.Parameter(typeof(Test));
	var callExpr=Expression.Call(objectPar, xPropSetter, newValPar);
	var setterAction = (Action<Test,int>)
        Expression.Lambda(callExpr, objectPar, newValPar).Compile();
	Test val = new Test();
	Console.WriteLine(val.X);//0
	setterLambda(val,42);
	Console.WriteLine(val.X);//42
    
