        public class ModelResourceFilterAttribute : Attribute, IResourceFilter
        {
            public void OnResourceExecuted(ResourceExecutedContext context)
            {
            }
            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                context.HttpContext.Request.EnableRewind();
                var routeData = context.RouteData;
                var stream = context.HttpContext.Request.Body;
                using (var streamReader = new StreamReader(context.HttpContext.Request.Body))
                {
                    var json = streamReader.ReadToEnd();
                    if (json != "")
                    {
                        var jsonObj = JObject.Parse(json);
                        foreach (var item in routeData.Values)
                        {
                            JToken token;
                            if (jsonObj.TryGetValue(
                                item.Key,
                                StringComparison.InvariantCultureIgnoreCase,
                                out token))
                            {
                                var jProperty = token.Parent as JProperty;
                                if (jProperty != null)
                                {
                                    jProperty.Value = item.Value.ToString();
                                }
                            }
                        }
                        var body = jsonObj.ToString(Formatting.Indented);
                        byte[] byteArray = Encoding.UTF8.GetBytes(body);
                        //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                        context.HttpContext.Request.Body = new MemoryStream(byteArray);
                    }
                    
                }            
            }
        }
