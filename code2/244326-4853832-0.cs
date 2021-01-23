    public interface ITopicComposite
    {
    	// <Methods and properties folder and content have in common (e.g. a title)>
    	// They should be meaningful so you can just pick a child
    	// out of a folder and for example use a method without the
    	// need to check if it's another folder or some content.
    }
    
    public class TopicFolder : ITopicComposite
    {
    	private readonly ObservableCollection<ITopicComposite> children = new ObservableCollection<ITopicComposite>();
    	public ObservableCollection<ITopicComposite> Children
    	{
    		get { return children; }
    	}
    
    	//...
    }
    
    public class TopicInfo : ITopicComposite
    {
    	//...
    }
