            public static byte[] Serialize(this StanjeZalihaLek data)
            {
                var sb = new StringBuilder();
    
                using (var tw = new System.IO.StringWriter(sb))
                {
                    Newtonsoft.Json.JsonTextWriter jsonWriter = new JsonTextWriter(tw);
                    jsonWriter.WriteStartObject();     
                                    
                    jsonWriter.WriteRaw(JsonConvert
                                     .SerializeObject(data)
                                     .Substring(1)
                                     .TrimEnd('}'));
    
                    jsonWriter.WriteRaw(",");
                    
                    int inx = 0;
                    foreach (var item in data.ListaLek)
                    {
                        var str = $"{inx++}";
    
                        jsonWriter.WritePropertyName(str);
                        jsonWriter.WriteRawValue(JsonConvert.SerializeObject(item));
                    }
                    jsonWriter.WriteEndObject();
                    jsonWriter.Close();
    
                }
    
                return System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            }
