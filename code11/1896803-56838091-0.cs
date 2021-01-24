cs
public class User
{
	public string userId { get; set; }
	public string geoHash { get; set; }
	public double latitude { get; set; }
	public double longitude { get; set; }
	public DateTime locationDate { get; set; }
}
Then this code deserializes the user data and projects it as a FeatureCollection:
cs
	var users = JsonConvert.DeserializeObject<List<User>>(json);
	var userGeo = users.Select(u => new
		{
			type = "Feature",
			geometry = new
			{
				type = "Point",
				coordinates = new double[] { u.longitude, u.latitude }
			},
			properties = new {
				name = "User " + u.userId.Trim()
			}
		}
	);
	
	var featureCollection = new {
		type = "FeatureCollection",
		features = userGeo
	};
	
	var geoJson = JsonConvert.SerializeObject(featureCollection, Formatting.Indented);
Output:
js
{
  "type": "FeatureCollection",
  "features": [
    {
      "type": "Feature",
      "geometry": {
        "type": "Point",
        "coordinates": [
          5.689,
          1.234
        ]
      },
      "properties": {
        "name": "User 1"
      }
    },
    {
      "type": "Feature",
      "geometry": {
        "type": "Point",
        "coordinates": [
          5.689,
          1.234
        ]
      },
      "properties": {
        "name": "User 2"
      }
    },
    {
      "type": "Feature",
      "geometry": {
        "type": "Point",
        "coordinates": [
          5.689,
          1.234
        ]
      },
      "properties": {
        "name": "User 3"
      }
    }
  ]
}
