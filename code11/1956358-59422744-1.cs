        public class JsonBody
        {
            public int someint;
            public List<Item> item;
            public string somestring;
        }
As mentionned by @Lasse V. Karlsen it need to be deserialized into a list of JsonBody, so you have to alter this line of code as well:
var items = JsonConvert.DeserializeObject<List<JsonBody>>(json);
