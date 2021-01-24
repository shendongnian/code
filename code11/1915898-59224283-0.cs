    public static dynamic FromJson(this string json, JsonSerializerOptions options = null)
        {
            if (string.IsNullOrEmpty(json))
                return null;
            try
            {
                return JsonSerializer.Deserialize<ExpandoObject>(json, options);
            }
            catch
            {
                return null;
            }
        }
