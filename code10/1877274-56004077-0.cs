     void Build(ChildClassA obj)
     {
         obj.MethodA();
     }
     void Build(ChildClassB obj)
     {
         obj.MethodB();
     }
    And call
    Build((dynamic) baseClassObj);
