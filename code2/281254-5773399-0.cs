    public class ClassA
    {
        public String SomeParam { get; set; }
        public ClassA(ClassA myoldobject)
        {
               //Logic for initializing new object.
               this.SomeParam = myoldobject.SomeParam;
        }
        public ClassA(String someparam)
        {
               this.SomeParam = someparam;
        }
    }
