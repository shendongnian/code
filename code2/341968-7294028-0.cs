    abstract class Command : ICommand
    {
       public int Id {get;set;}
       public abstract void Execute();
    }
    class CommandA : Command
    {
       public int X {get;set;}
       public int Y {get;set;}
       public override void Execute () { ... }
    }
    class CommandB : Command
    {
       public string Name {get;set;}
       public override void Execute () { ... }
    }
