    public class MNyTestAgent: AgentBase
    {
       RaiseMessage('hey', 'hey')
    
       var a = new Foo(this);
    }
    
    public class Foo
    {
       public Foo()
       {
       }
       public Foo(AgentBase Base)
       {
          Base.RaiseMessage('','') -<< how do i use it here 
       }
    }
