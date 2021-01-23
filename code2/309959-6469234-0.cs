    // Have some object hold the type of method it plans on calling.
    enum methodNames
    {
       Method1,
       Method2
    }
    
    ...
    class someObject
    {
       internal methodNames methodName {get; set;}
       internal object[] myParams;
    }
    ...
    
    //  Execute your object based on the enumeration value it references.
    switch(methodName)
    {
       case Method1:
          Test.Method1(Int32.Parse(myParams[0].ToString),myParams[1].ToString());
          break;
       ...
    }
