    using Newtonsoft.Json;
    class JsonResponse
    {
        public string Response { get; set; }
    }
    class Utility
    {
        public JsonResponse JsonDeserialisation(string response)
        {
            TextReader textReader = new StreamReader(response);
            JsonTextReader jsonReader = new JsonTextReader(textReader);
            return JsonSerializer.CreateDefault().Deserialize<JsonResponse>(jsonReader);
        }
    }
    class Main
    {
        static void Program()
        {
            var ResultJSON = "Json String received from post";//Post(uri, values);
            var deserialisedJson = Utility.JsonDeserialisation(ResultJSON);
        }
    }
