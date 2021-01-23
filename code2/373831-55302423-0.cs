        static private T CleanJson<T>(string jsonData)
        {
            var json = jsonData.Replace("\t", "").Replace("\r\n", "");
            var loop = true;
            do
            {
                try
                {
                    var m = JsonConvert.DeserializeObject<T>(json);
                    loop = false;
                }
                catch (JsonReaderException ex)
                {
                    var position = ex.LinePosition;
                    var invalidChar = json.Substring(position - 2, 2);
                    invalidChar = invalidChar.Replace("\"", "'");
                    json = $"{json.Substring(0, position -1)}{invalidChar}{json.Substring(position)}";
                }
            } while (loop);
            return JsonConvert.DeserializeObject<T>(json);
        }
