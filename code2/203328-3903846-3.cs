    public interface ICommand
    {
        // Cancel processing, do not invoke any more handlers
        public bool Cancel { get; set; }
    }
    public class CommandDispatcher 
    {
      private Dictionary<Type, List<Action<ICommand>>> _commands = new Dictionary<Type, List<Action<ICommand>>>();
      // Add to dictionary here
      public void Subscribe<T>(Action<T> action) where T : ICommand
      {
          List<Action<ICommand>> subscribers;
          if (!_commands.TryGetValue(typeof(T), out subscribers))
          {
              subscribers = new List<Action<ICommand>>();
              _commands.Add(typeof(T), subscribers));
          }
          subscribers.Add(action);
      }
      // find command and to foreach to execute the actions      
      public void Trigger<T>(T command) where T : ICommand
      {
          List<Action<ICommand>> subscribers;
          if (!_commands.TryGetValue(typeof(T), out subscribers))
              throw new InvalidOperationException("There are no subscribers for that command");
          foreach(var subsriber in subscribers)
          {
              subscriber(command);
              if (command.Cancel)
                  break; //a handler canceled the command to prevent others from processing it.
          }
      }
    }
    public class AddTextCommand : ICommand
    {
        public string TextToAdd {get;set;}
    }
    public class TextHandler
    {
        public TextHandler(CommandDispatcher dispatcher)
        {
            disptacher.Subscribe<AddTextCommand>(OnAddText);
        }
        public void OnAddText(AddTextCommand cmd)
        {
            //....
        }
    }
    public partial class MyForm : Form
    {
        CommandDispatcher _dispatcher;
        private void MyTextBox_Changed(object source, EventArgs e)
        {
            _dispatcher.Trigger(new AddTextCommand{TextToAdd = MyTextBox.Text}=;
        } 
    }
