    public class Element 
    {
    	public ObservableCollection<Element> Elements = new ObservableCollection<Element>();
    	
    	public Element(string filename) 
    	{
    		StreamReader reader = new StreamReader(locationtreeFile, Encoding.UTF8);
    		XDocument doc = XDocument.Load(reader);
    		Elements = LoadUnits(doc.Descendants("componentRef"));
    	}
    }
