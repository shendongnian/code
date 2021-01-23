    public static String ToJSONString(this Object obj)
            {
                using (var stream = new MemoryStream())
                {
                    var ser = new DataContractJsonSerializer(typeof(object));
                    ser.WriteObject(stream, obj);
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
