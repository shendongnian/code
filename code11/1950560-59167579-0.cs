    public class ErrorBody
    {
    	public double Sampling_Fraction { get; set; }
    	public string Server_Ip { get; set; }
    	public string Protocol { get; set; }
    	public string Method { get; set; }
    	public Dictionary<string, List<string>> Request_Headers { get; set; }  // change type here
    	public Dictionary<string, List<string>> Response_Headers { get; set; } // change type here
    	public int Status_Code { get; set; }
    	public string Type { get; set; }
    }
    void Main()
    {
    	var str = "{\"sampling_fraction\":1,\"server_ip\":\"192.0.2.1\",\"protocol\":\"http\\/1.1\",\"method\":\"GET\",\"request_headers\":{\"If-None-Match\":[\"01234abcd\"]},\"response_headers\":{\"ETag\":[\"01234abcd\"]},\"status_code\":304,\"type\":\"ok\"}";
    	JsonConvert.DeserializeObject<ErrorBody>(str); // this gave me deserialised object
    }
