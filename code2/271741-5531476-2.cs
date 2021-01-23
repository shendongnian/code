    void Main()
    {
    	var measurements = GetMeasurements(@"C:\path\to\file\measurements.xml");
    }
    
    public List<Measurement> GetMeasurements(string path)
    {
    	XDocument doc = XDocument.Load(path);
    	
    	return (from s in doc.Descendants("Measurement")
    			select new Measurement
    			{
    				 Longitude = Convert.ToDecimal(s.Element("longitude").Value),
    				 Latitude = Convert.ToDecimal(s.Element("latitude").Value),
    				 City = s.Element("city").Value,
    			}).ToList();
    }
    
    public class Measurement
    {
    	public decimal Longitude { get; set; }
    	public decimal Latitude { get; set; }
    	public string City { get; set; }
    }
