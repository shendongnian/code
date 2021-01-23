    public class A
    {
         private A(){}
         // Here B can inherit from A
         public class B : A{}
     }
     // This is not allowed
     public class C : A{}
