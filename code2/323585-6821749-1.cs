    public class SomeCommand : ICommand
    {
        private T yourObj;
 
        public SomeCommand(T yourObj)
        {
            this.yourObj = yourObj;
        }
        public void Execute(object param)
        {
            // do something with yourObj
        }
        // other ICommand members...
    }
