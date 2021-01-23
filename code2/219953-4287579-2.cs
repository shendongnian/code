    class Base_Data
    {
        public virtual void Check() { ... }
    }
    class Person : Base_Data
    {
        public override void Check()
        {
            ... // <-- do whatever you would have done inside the if block
        }
    }
    class AnotherClass
    {
        public void CheckData(Base_Data data)
        {
             data.Check();
        }
    }
