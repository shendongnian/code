    private string ReplaceNameTags(string uri, dynamic arguments)
        {
            string result = uri;
            var properties = arguments.GetType().GetProperties();
            foreach (var prop in properties)
            {
                object propValue = prop.GetValue(arguments, null);
                result = Regex.Replace(uri, $"{{{prop.Name}}}", propValue.ToString());
            }
            return result;
        }
