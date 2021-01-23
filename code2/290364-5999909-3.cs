    class MyObjBase
    {
         public virtual string myProperty { get; set; }
         
         public void Foo()
         {
             myProperty = "something";   // refers to derived class property, if
                                         // it overrides myProperty
         }
         ...
    }
    class MyObj: MyObjBase, IMyObj
    {
       
        public override string myProperty { get; set; }
        public string Bar()
        {   
            base.myProperty = "Hello ";
            myProperty = "World";
            return base.myProperty + myProperty;   // returns "Hello World"
        }
        ...
    }
