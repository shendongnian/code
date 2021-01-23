    public interface ICommand
    {
    	void Execute();
    
    	bool CanExecute { get; }
    }
