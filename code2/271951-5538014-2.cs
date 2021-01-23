    public interface IBar
    {
       void DoSimpleStudd();
       int This {get;}
     
    }
    
    public interface ISuperBar : IBar
    {
       void DoComplexStuff();
       int That {get; set;}
     
    }
    // at service layer
    public class ServiceWidget
    {
        public ISuperBar Bar {get; set;}
        ...
    }
    
    // other places
    public class ServiceWidget
    {
        public IBar Bar {get; set;}
        ...
    }
