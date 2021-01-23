    public class IsoStoreHelper
    {
    	private static IsolatedStorageFile _isoStore;
    	public static IsolatedStorageFile IsoStore 
    	{ 
    		get { return _isoStore ?? (_isoStore = IsolatedStorageFile.GetUserStoreForApplication()); }
    	}
    
    	public static void SaveList<T>(string folderName, string dataName, ObservableCollection<T> dataList) where T : class
    	{
    		if (!IsoStore.DirectoryExists(folderName))
    		{
    			IsoStore.CreateDirectory(folderName);
    		}
    
    		string fileStreamName = string.Format("{0}\\{1}.dat", folderName, dataName);
    
    		using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileStreamName, FileMode.Create, IsoStore))
    		{
    			DataContractSerializer dcs = new DataContractSerializer(typeof(ObservableCollection<T>));
    			dcs.WriteObject(stream, dataList);
    		}
    	}
    
    	public static ObservableCollection<T> LoadList<T>(string folderName, string dataName) where T : class
    	{
    		ObservableCollection<T> retval = new ObservableCollection<T>();
    
    		string fileStreamName = string.Format("{0}\\{1}.dat", folderName, dataName);
    
    		using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileStreamName, FileMode.OpenOrCreate, IsoStore))
    		{
    			if (stream.Length > 0)
    			{
    				DataContractSerializer dcs = new DataContractSerializer(typeof(ObservableCollection<T>));
    				retval = dcs.ReadObject(stream) as ObservableCollection<T>;
    			}
    		}
    
    		return retval;
    	}
    }
