{
	"userId": 321,
	"account": "new",
	"fname": "Adam",
	"lname": "Silver",
	"features": [{
		"available": true,
		"status": "open",
		"admin": false
	}]
}
you can use below class in your web API to pass respective data
public class Feature
{
    public bool available { get; set; }
    public string status { get; set; }
    public bool admin { get; set; }
}
public class RootObject
{
    public int userId { get; set; }
    public string account { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public List<Feature> features { get; set; }
}
 
then at the end, while returning data, convert the respective class object into JSON by serializing that into JSON format.
Hope it will fulfill your requirement.
