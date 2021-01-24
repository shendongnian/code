    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class Userobject
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public long Password { get; set; }
    }
