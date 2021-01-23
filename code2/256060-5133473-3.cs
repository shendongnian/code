    Expression<Func<MyClass1, bool>> exp1 = x => x.field1 == 100;
    
    var visitor = new MyExpressionVisitor(Expression.Parameter(typeof(MyClass2), 
                            exp1.Parameters[0].Name));
     
    var exp2 = Expression.Lambda<Func<MyClass2, bool>>
                    (visitor.Visit(exp1.Body), visitor.NewParameterExp);
    
    //the following is for testing
    var data = new MyClass2();
    Console.WriteLine(exp2.Compile()(data));  //False
    data.field1 = 100;
    Console.WriteLine(exp2.Compile()(data));   //True
