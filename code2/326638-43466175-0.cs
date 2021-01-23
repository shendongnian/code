            internal static string SerializeToString_PB<T>(this T obj)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(ms, obj);
                    return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                }
            }
            internal static T DeserializeFromString_PB<T>(this string txt)
            {
                byte[] arr = Convert.FromBase64String(txt);
                using (MemoryStream ms = new MemoryStream(arr))
                    return ProtoBuf.Serializer.Deserialize<T>(ms);
            }
