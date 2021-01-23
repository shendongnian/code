    public interface ICommand 
    {
       public void Execute();
    }
    
    public class Command1 : ICommand
    {
       public Command1(int param1, string param2)
       {
       }
    
       ...
    }
    
    public class Command2 : ICommand
    {
      ...
    }
    
    public class Program
    {
    
       public static void Main()
       {
    
           ...
    
           var commands = new List<Action>();
           commands.Add((new Command1(3, "Hello")).Execute);
           commands.Add((new Command2(...)).Execute);
    
           ...
       }
   
    
    }
