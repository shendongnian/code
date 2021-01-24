	public class RegistrantInfoResponse
    {
        public string questionid { get; set; }
        public string fieldname { get; set; }
        public string name { get; set; }
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> response { get; set; }
    }
    public class RegistrantInfo
    {
        public string attendeeid { get; set; }
        public Dictionary<string, RegistrantInfoResponse> responses { get; set; }
    }
