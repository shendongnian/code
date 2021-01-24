    public class JsonStreamingResult : ActionResult
    {
        private IEnumerable itemsToSerialize;
        public JsonStreamingResult(IEnumerable itemsToSerialize)
        {
            this.itemsToSerialize = itemsToSerialize;
        }
        public override void ExecuteResult(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(response.Body, Encoding.UTF8))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartArray();
                foreach (object item in itemsToSerialize)
                {
                    JObject obj = JObject.FromObject(item, serializer);
                    obj.WriteTo(writer);
                    writer.Flush();
                }
                writer.WriteEndArray();
            }
        }
    }
