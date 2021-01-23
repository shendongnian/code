    private static T ConvertFromString<T>(string text)
        {
            if (typeof(Enum).IsAssignableFrom(typeof(T)))
            {
                try
                {
                    return (T)Enum.Parse(typeof(T), text);
                }
                catch (ArgumentException e)
                {
                    return default(T);
                }
            }
            return (T)Convert.ChangeType(text, typeof(T));
        }
