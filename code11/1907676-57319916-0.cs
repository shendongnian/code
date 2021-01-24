    public class Metadata
    {
        public string code { get; set; }
        public string message { get; set; }
    }
    public class Rujukan
    {
        public object asalRujukan { get; set; }
        public object tglRujukan { get; set; }
        public string noRujukan { get; set; }
        public object ppkRujukan { get; set; }}
    public class Response
    {
        public string noSep { get; set; }
        public object noKartu { get; set; }
        public object tglSep { get; set; }
        public object peserta { get; set; }
        public object tglPulang { get; set; }
        public string jnsPelayanan { get; set; }
        public object klsRawat { get; set; }
        public object noMR { get; set; }
        public Rujukan rujukan { get; set; }
    }
    public class RootObject
    {
        public Metadata metadata { get; set; }
        public Response response { get; set; }
    }
    var rootObject = new RootObject();
    var json = JsonConvert.SerializeObject(rootObject);   
