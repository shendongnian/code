    namespace Busker.Data.Commands
    {
        /// <summary>
        /// The 'Command' abstract class
        /// </summary>
        public abstract class Command
        {
    
            private string message = "";
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
    
    
            private bool success = false;
            public bool Success
            {
                get { return success; }
                set { success = value; }
            }
    
            private Validator validator = new Validator();
            public Validator Validator
            {
                get { return validator; }
                set { validator = value; }
            }
    
            private CommandStatusCode statusCode = CommandStatusCode.OK;
            public CommandStatusCode StatusCode
            {
                get { return statusCode; }
                set { statusCode = value; }
            }
    
            public LoggingLevel LoggingLevel = LoggingLevel.Debug;
    
    
            //public BuskerContext BuskerContext;
    
    
            public bool IsValid()
            {
                if (validator.Errors.Count > 0)
                    return false;
                return true;
    
            }
    
            public abstract void Execute();
    
            public void FailedSubCommand(Command cmd) 
            {
                this.Success = cmd.Success;
                this.Message = cmd.message;
            }
        }
    }
    
    
    namespace Busker.Data.Commands
    {
        public class Invoker
        {
            private Command command;
    
            public Command Command
            {
                get { return command; }
                set { command = value; }
            }
    
    
            public void SetCommand(Command command)
            {
                this.Command = command;
            }
    
            public virtual void ExecuteCommand()
            {
                if (command == null)
                    throw new Exception("You forgot to set the command!!");
    
                try
                {
                    log(this.command.GetType().Name + " starting execution ");
                    command.Execute();
                    if (!command.Success)
                    {
                        log(this.command.GetType().Name + " completed execution but failed. Message: " + command.Message + " " + command.StatusCode.ToString());
                    }
                    else
                        log(this.command.GetType().Name + " completed execution. Success!");
    
                }
                catch (Exception ex)
                {
                    command.StatusCode = CommandStatusCode.Error;
                    Loggy.AddError("An unhandled error was caught in " + this.command.GetType().Name + ": " + ex.Message, ex);
                    command.Message = ex.ToString();
                    //throw;
                }
            }
    
            private void log(string msg)
            {
                switch (command.LoggingLevel)
                {
                    case Busker.Data.Constants.LoggingLevel.Debug:
                        Loggy.Debug(msg);
                        break;
                    case Busker.Data.Constants.LoggingLevel.Off:
                        break;
                    default:
                        Loggy.Add(msg);
                        break;
    
                }
    
            }
    
            public virtual void ExecuteLinqCommand()
            {
                this.ExecuteCommand();
            }
        }
    }
    
    namespace Busker.Data.Commands
    {
      public static class Extensions
      {
            /// <summary>
            /// Executes the command using the default invoker.
            /// </summary>
            /// <param name="aCommand"></param>
            public static void Invoke(this Command aCommand)
            {
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
                System.Reflection.MethodBase m = stackTrace.GetFrame(1).GetMethod();
                String strMethodName = m.DeclaringType.Name + "." + m.Name;
    
                try
                {
                    Invoker invoker = new Invoker();
                    invoker.SetCommand(aCommand);
                    invoker.ExecuteCommand();
                }
                catch (Exception ex)
                {
                    Loggy.AddError("An error occured in Extensions.Invoke. + " + strMethodName ,ex);
                    throw ex;
                }
                
            }
    }
