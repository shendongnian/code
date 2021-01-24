    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace WpfApp1
    {
    /*
       Json class to compile the full embed
       Action: n/a
    */
    public class Json
    {
        // 'Username' value
        [JsonProperty("username")]
        public string username { get; set; }
        // 'Avatar' value
        [JsonProperty("avatar_url")]
        // 'Content' value --> Always empty because we are using embed
        public string avatarurl { get; set; }
        [JsonProperty("content")]
        public string content { get; set; }
        // 'Embed' array value
        [JsonProperty("embeds")]
        public List<Embed> embeds { get; set; }
    }
    /*
       Json class to compile the single embed
       Action: n/a
    */
    public class Embed
    {
        [JsonProperty("author")]
        public Author author { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("color")]
        public int color { get; set; }
        [JsonProperty("fields")]
        public List<Field> fields { get; set; }
        [JsonProperty("thumbnail")]
        public Thumbnail thumbnail { get; set; }
        [JsonProperty("image")]
        public Image image { get; set; }
        [JsonProperty("footer")]
        public Footer footer { get; set; }
    }
    /*
       Json class to compile the author in an embed
       Action: n/a
    */
    public class Author
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("icon_url")]
        public string iconurl { get; set; }
    }
    /*
       Json class to compile the fields in an embed
       Action: n/a
    */
    /*
       Json class to compile the thumbnail in an embed
       Action: n/a
    */
    public class Thumbnail
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }
    /*
       Json class to compile the image in an embed
       Action: n/a
    */
    public class Image
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }
    /*
       Json class to compile the footer in an embed
       Action: n/a
    */
    public class Footer
    {
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("icon_url")]
        public string iconurl { get; set; }
    }
    /*
       Json class to compile the config
       Action: CONFIG
    */
    public class Config
    {
        [JsonProperty("webhook_url")]
        public string webhook { get; set; }
        [JsonProperty("json")]
        public Json json { get; set; }
    }
    public class Field
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("value")]
        public string value { get; set; }
        [JsonProperty("inline")]
        public bool inline { get; set; }
    }
    }
