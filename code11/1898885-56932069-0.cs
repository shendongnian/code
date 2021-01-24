public abstract class AgentBase
{
   public static RaiseMessage(string title, string message)
   {
        // Implementation.
   }
}
public class MNyTestAgent: AgentBase
{
    public MNyTestAgent()
    {
        AgentBase.RaiseMessage("hey", "hey");
    }
}
public class Foo
{
   public Foo()
   {
      AgentBase.RaiseMessage("hey", "hey");
   }
}
