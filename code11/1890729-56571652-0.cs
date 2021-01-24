    public interface BaseInterface { }
    public interface ChildInterface : BaseInterface { }
    
    public class ConcreteClass : AbstractClass<ChildInterface> { }
 
    
