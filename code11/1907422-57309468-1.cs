    public class Parent 
    {
    
       public List<ChildA> ChildListA { get; set;}
       public List<ChildB> ChildListB { get; set;}
    
    }
    public class ChildA:Parent
    {
    
    }
    public class ChildB:Parent
    {
    
    }
    var parentList= new List<Parent>();
    
    parentList.Add( new Parent() { ChildListA=new List<ChildA>(),  ChildListB=new List<ChildB>()}); 
    // assuming parent is not abstract
    
