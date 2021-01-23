    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text;
    public static class Extensions
    {
        public static StringContent AsJson(this object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
