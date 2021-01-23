    public class ScheduledPostEntity : Azure.AzureTableEntity
    {
    	private Guid _userGuid;
    	private DateTime _dateScheduled;
    
    	public ScheduledPostEntity()
    	{
    		// Needed for deserialisation from Azure Table Storage
    	}
    
    	public ScheduledPostEntity(Guid userGuid, DateTime dateScheduled)
    	{
    		_userGuid = userGuid;
    		_dateScheduled = dateScheduled;
    	}
    
    	public string PartitionKey
    	{
    		get { return _userGuid.ToString(); }
    		set { _userGuid = Guid.Parse(value); }
    	}
    
    	public string RowKey
    	{
    		get { return _dateScheduled.ReverseTicks(); }
    		set { _dateScheduled = value.FromReverseTicks(); }
    	}
    
    	// These are functions to avoid them being saved as additional properties
    	// in Azure Table Storage.  Sometimes you can get away with them being
        // read only properties, but it depends on the type.
    	public DateTime DateScheduled()
    	{
    		return _dateScheduled;
    	}
    
    	public Guid UserGuid()
    	{
    		return _userGuid;
    	}
    }
