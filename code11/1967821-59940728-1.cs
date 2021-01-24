    public class Event
    {
        public string eventId { get; set; }
        public string time { get; set; }
        public string agency { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string depth { get; set; }
        public string rms { get; set; }
        public string type { get; set; }
        public string m { get; set; }
        public object place { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string town { get; set; }
        public string other { get; set; }
        public object mapImagePath { get; set; }
        public object strike1 { get; set; }
        public object dip1 { get; set; }
        public object rake1 { get; set; }
        public object strike2 { get; set; }
        public object dip2 { get; set; }
        public object rake2 { get; set; }
        public object ftype { get; set; }
        public object pic { get; set; }
        public object file { get; set; }
        public object focalId { get; set; }
        public string time2 { get; set; }
    }
You can use the above class in main program like,
    var client = new RestClient("https://deprem.afad.gov.tr/latestCatalogsList");
    client.Timeout = -1;
    var request = new RestRequest(Method.POST);
    request.AddHeader("Content-Type", "multipart/form-data");
    request.AlwaysMultipartFormData = true;
    request.AddParameter("m", "0");
    request.AddParameter("utc", "0");
    request.AddParameter("lastDay", "1");
    var response = client.Execute<List<Event>>(request);
    List<Event> myData = response.Data;
    Console.WriteLine(response.Content);
You will have an object with all the data from the site. You can do whatever you need to with that data.
*Please do mark the post answered if it helped*
