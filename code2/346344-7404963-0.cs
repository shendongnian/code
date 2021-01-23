    public class MyExtendedClass : IMyClass
    {
        public MyExtendedClass(IMyClass myClass)
        {
            this.innerMyClass= myClass;
        }
    
        public void AddObject(MyObject mo)
        {
           // does mo have an attribute on AddObject
           // if so
           mo.TheTime = DateTime.Now;
           innerMyClass.AddObject(mo);
        } 
    }
