    public interface ICommand
    {
        // Cancel processing, do not invoke any more handlers
        public bool Cancel { get; set; }
    }
    public class CommandDispatcher 
    {
      private Dictionary<Type, List<Action<ICommand>>> _commands = new Dictionary<Type, List<Action<ICommand>>>();
      // Add to dictionary here
      public void Subscribe<T>(Action<ICommand> action) where T : ICommand
      // find command and to foreach to execute the actions      
      public void Trigger<T>() where T : ICommand
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
