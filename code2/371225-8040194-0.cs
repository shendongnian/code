    interface ICommand {
        void Execute();
    }
    
    interface IEventCommand : ICommand {
        void Execute(object sender, EventArgs e); 
    }
 
    class CommandAttribute : Attribute {
         ...
    }
    class MyCommand : IEventCommand {
         ...
    }
