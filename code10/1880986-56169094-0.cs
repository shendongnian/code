    using System;
    using Newtonsoft.Json;
    {
        public class JsonHandler : IJsonHandler
        {
            public IJsonModel ReadJson(IJsonModel model, StreamReader reader)
            {
                try
                {
                    string jsonFromFile;
                    using (reader))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }
    
                    status = JsonConvert.DeserializeObject<model>(jsonFromFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return status;
            }
        }
    }
