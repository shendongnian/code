    public class Command
    {
        public Command(Action execute, Action undo)
        {
            Execute = execute;
            Undo = undo;
        }
        public Action Execute { get; protected set; }
        public Action Undo { get; protected set; }
    }
