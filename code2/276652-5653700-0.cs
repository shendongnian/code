    class Address
    {
        public string Street { get; set; }
        public IPostalCode PostalCode { get; set;}
    }
    public interface IPostalCode
    {
        int? Usa { get; }
        string Canadian { get; }
    }
    public class UsaPostalCode
    {
        private int _code;
        public UsaPostalCode(int code) { _code = code; }
        public int? Usa { get { return _code; }
        public string Canadian { get { return null; }
    }
    public class CanadianPostalCode
    {
        private string _code;
        public CanadianPostalCode(string code) { _code = code; }
        public int? Usa { get { return null; }
        public string Canadian { get { return _code; }
    }
