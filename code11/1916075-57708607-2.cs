    public abstract class CommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        protected CommandHandler(string type, string name)
        {
            //Business logic
        }
        //Making Run method abstract so that 
        //individual Handler class can have their own logic in it.
        public abstract void Run(T command);
        //Common implementation for LogWrite.
        //If this also requires override, it can be made virtual 
        //so that deriving class can override the logic.
        protected void LogWrite(T command)
        {
            //Writing log 
        }
    }
    //PetCommandHandler class now can be used for any class object 
    //which is inheriting PetCommand class.
    public class PetCommandHandler<T> : BaseCommandHandler<T> where T: PetCommand
    {
        public PetCommandHandler(string type, string name) : base(type, name)
        {
        }
        public override void Run(T dCommand)
        {
            this.LogWrite(dCommand);
        }
    }
