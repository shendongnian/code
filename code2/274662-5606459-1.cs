    public class ProcessStringCommand : ICommand
    {
       private readonly IProcessStringViewModel m_viewModel;
       
       public ProcessStringCommand(IProcessStringViewModel vm)
       {
          m_viewModel = vm;
       }
       
       public void Execute(object param)
       {
          ProcessString(m_viewModel.ProcessString);
       }
   
       public bool CanExecute(object param)
       { 
          return true; 
       }
       
       private void ProcessString(string processString)
       {
          // Put logic here
       }
    }
    public interface IProcessStringViewModel
    {
       public string ProcessString { get; }
    }
    public class ViewModel1 : ViewModelBase, IProcessStringViewModel
    {
       private readonly ICommand m_command;
       private readonly string m_processString;
       
       public ViewModel1()
       {
          m_command = new ProcessStringCommand(this);
       }
       
       public string ProcessString
       {
          get { return m_processString; }
       }
       
       public ICommand ProcessStringCommand
       {
          get { return m_command; }
       }
    }
    public class ViewModel2 : ViewModelBase, IProcessStringViewModel
    {
       private readonly ICommand m_command;
       private readonly string m_processString;       
       
       public ViewModel2()
       {
          m_command = new ProcessStringCommand(this);
       }
       
       public string ProcessString
       {
          get { return m_processString; }
       }
       
       public ICommand ProcessStringCommand
       {
          get { return m_command; }
       }
    }
    
    public class ViewModel3 : ViewModelBase
    {
       // Whatever you need here.
    }
