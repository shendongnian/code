    [AutoMap(typeof(Manifest), ReverseMap = true)]
    public class ViewModel
    {
    	......other stuff
    
    	[NotMapped]
    	[JsonIgnore]
    	private IList<EntryViewModel> _entries;
    
    	[JsonIgnore]
    	public virtual IList<EntryViewModel> Entries
    	{
    		get
    		{
    			if (_entries == null)
    				_entries = new List<EntryViewModel>();
    
    			return _entries.Where(m => !m.Deleted).ToList();
    		}
    		set => _entries = value;
    	}
    
    	public void AddEntry(EntryViewModel entry)
    	{
    		_entries.Add(entry);
    	}
    }
    
    [AutoMap(typeof(Manifest), ReverseMap = true)]
    public class DetailViewModel : ViewModel
    {
    	......other stuff
    
    	[NotMapped]
    	[JsonIgnore]
    	private IList<EntryDetailViewModel> _entries;
    
    	[JsonIgnore]
    	public new IList<EntryDetailViewModel> Entries
    	{
    		get
    		{
    			if (_entries == null)
    				_entries = new List<EntryDetailViewModel>();
    
    			return _entries.Where(m => !m.Deleted).ToList();
    		}
    		set => _entries = value;
    	}
    
    	public void AddEntry(EntryDetailViewModel entry)
    	{
    		_entries.Add(entry);
    	}
    }
