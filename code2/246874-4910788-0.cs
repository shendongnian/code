    public class Binding
    {
         public Binding(ConsoleKey key, Action action)
         {
                this.Key = key;
                this.Action = action;
         }
         public ConsoleKey Key { get; private set; }
         public Action Action { get; private set; }
    }
