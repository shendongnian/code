    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute {
        public CommandAttribute(int id) {
            ID = id;
        }
        public int ID { get; private set; }
    }
    public abstract class Command {
        public abstract void Execute();
    }
    [Command(2)]
    public class MyCommand : Command {
        public override void Execute() {
            //Do something useful
        }
    }
