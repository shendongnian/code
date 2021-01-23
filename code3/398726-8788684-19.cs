    public class Command 
    {
        private readonly Action _execute;
        private readonly Action _undo;
        public Command(Action execute, Action undo)
        {
            _execute = execute;
            _undo = undo;
        }
        public void Execute()
        {
            _execute();
        }
        public void Undo()
        { 
            _undo();
        }
    }
