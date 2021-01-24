    public static Dictionary<string, string> convert(object content)
            {
               
                var props = content.GetType().GetProperties();
                var pairDictionary = props.ToDictionary(x => x.Name,x=>x.GetValue(content,null)?.ToString());
                return pairDictionary;
            }
