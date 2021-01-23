    public class Feeds
    {
        public bool authenticated;
        public string user;
        public Dictionary<string, Feed> feeds;
        public void ReadJson(JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                    break;
                if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "authenticated")
                {
                    reader.Read();
                    authenticated = (bool)reader.Value;
                }
                else if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "user")
                {
                    reader.Read();
                    user = (string)reader.Value;
                }
                else if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "feeds")
                {
                    feeds = new Dictionary<string, Feed>();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.EndObject)
                            break;
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            string key = (string)reader.Value;
                            feeds.Add(key, Feed.ReadFromJson(reader));
                        }
                    }
                }
            }
        }
        public static Feeds ReadFromJson(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                using (Newtonsoft.Json.JsonReader jsonReader = new Newtonsoft.Json.JsonTextReader(sr))
                {
                    Feeds feeds = new Feeds();
                    feeds.ReadJson(jsonReader);
                    return feeds;
                }
            }
        }
    }
     
    public class Feed
    {
        public string feed_address;
        public string updated;
        public void ReadJson(JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                    break;
                if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "feed_address")
                {
                    reader.Read();
                    feed_address = (string)reader.Value;
                }
                else if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "updated")
                {
                    reader.Read();
                    updated = (string)reader.Value;
                }
            }
        }
        public static Feed ReadFromJson(JsonReader reader)
        {
            Feed feed = new Feed();
            feed.ReadJson(reader);
            return feed;
        }
    }
 
