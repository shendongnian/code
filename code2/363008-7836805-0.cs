    public class FormattedClass<T>
    {
    	List<T> ItemList { get; set; }
    	string Json { get; set; }
    	XmlDocument Document { get; set; }
    }
    
    public FormattedClass<T> GetItems<T>(long primaryKey)
