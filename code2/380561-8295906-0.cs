        using System.Text;
        using System.Runtime.Serialization.Json;
        using System.IO;
    
    ...
    
        public static string ToJSON(this object obj)
                {
                    string json = string.Empty;
        
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());
        
                    using ( MemoryStream ms = new MemoryStream() )
                    {
                        ser.WriteObject(ms, obj);
                        json = Encoding.Default.GetString(ms.ToArray());
                    }
        
                    return json;
                }
...
    HttpContext.Current.Response.Write(ToJSON(id));
