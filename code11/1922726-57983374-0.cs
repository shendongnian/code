    public class Data
    {
    	public string Country { get; set; }
    	public string Date { get; set; }
        // Deserialise the array as a list of 'SpeakerItem'
    	public List<SpeakerItem> Speaker { get; set; }
    
        // These will throw exceptions if the id doesn't match, but it's a start
    	public string Name => Speaker.Single(s => s.Id == "name").Value;
    	public string Age => Speaker.Single(s => s.Id == "age").Value;
    	public string Topic => Speaker.Single(s => s.Id == "topic").Value;
    }
    
    public class SpeakerItem
    {
    	public string Id { get; set; }
    	public string Value { get; set; }
    }
