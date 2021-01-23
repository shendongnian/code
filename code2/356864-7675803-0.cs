    public class MyClass 
    { 
        public MyClass(IQueryable<MyClass> linq) 
        { 
            TheLinq = linq; 
        } 
     
        public IQueryable<MyClass> TheLinq { get; set; } 
     
    } 
