    public abstract class MyAbstractNetCommand {   
         public abstract void ExecuteCommand();
    } 
    public class ConcreteCommand : MyAbstractNetCommand {
        
        /*Here additional ConcreteCommand specific methods and state members*/
        public override ExecuteCommand() {
           // concrete iplementation
        }
    }
