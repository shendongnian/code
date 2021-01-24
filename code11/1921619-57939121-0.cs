    public class ViewModel
    {
        public TagPresenter Tags {get;}
        public ViewModel()
        {
            Tags = new TagPresenter();
    
            Tags.TagCollection.ListChanged += (object o, ListChangedEventargs e) => { DataAccessor.UpdateTag(o[e.NewIndex]); };
    
            foreach(var tag in DataAccessor.GetTags())
                Tags.TagCollection.Add(new TagEntity(tag, Tags.TagCollection));
        }
    }
    
    public class TagPresenter
    {
        public BindingList<TagBase> TagCollection {get;}
    
        public TagPresenter()
        {
            TagCollection = new BindingList<TagBase>();
        }
    }
    
    public abstract class TagBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged {get;}
    	
        public void NotifyPropertyChanged(string _property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_property));
        }
    }
    
    public class TagEntity : TagBase
    {
        public Command ChangeState {get;}
    
        public TagEntity(string tag, BindingList<TagBase> parent)
        {
            ChangeState = new Command(new Action(() => {
                NotifyPropertyChanged("Property");
            }));
        }
    
    }
