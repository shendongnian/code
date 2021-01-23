    public abstract class ViewModelBase : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged(string propertyName)
    	{
    		PropertyChangedEventHandler changed = PropertyChanged;
    		if (changed != null)
    		{
    			changed(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
    
    public class Container : ViewModelBase
    {
    	private string m_Objective;
    	private ProblemCollection m_Problems;
    
    	public Container()
    	{
    		m_Problems = new ProblemCollection();
    	}
    
    	public string Objective
    	{
    		get { return m_Objective; }
    		set
    		{
    			m_Objective = value;
    			OnPropertyChanged("Objective");
    		}
    	}
    
    	public ProblemCollection Problems
    	{
    		get { return m_Problems; }
    		set
    		{
    			m_Problems = value;
    			OnPropertyChanged("Problems");
    		}
    	}
    }
    
    public class Problem : ViewModelBase
    {
        private string m_Name;
    
        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
    
    public class ProblemCollection : ObservableCollection<Problem>
    {
    }
