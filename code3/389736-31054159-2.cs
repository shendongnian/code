    public static class ExtensionMethods
        {
            public static string TrimIfNotNull(this string value)
            {
                if (value != null)
                {
                    return value.Trim();
                }
                return null;
            }
        }
