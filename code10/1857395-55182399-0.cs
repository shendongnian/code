    public class ViewModel : INotifyPropertyChanged
    {
    	public PopulateDatagrid Populatedatagridwithobservablecollection
    	{
    		get
    		{
    			return _populatedatagridwithobservablecollection;
    		}
    		set
    		{
    			if (value != _populatedatagridwithobservablecollection)
    			{
    				_populatedatagridwithobservablecollection = value;
    				NotifyPropertyChanged(nameof(Populatedatagridwithobservablecollection));
    			}
    		}
    	}
    	private PopulateDatagrid _populatedatagridwithobservablecollection = new PopulateDatagrid();;
    }
