    public static string Path(string objectPath, object[] indexes)
    {
        string str = objectPath;
        if (indexes != null)
        {
            for (int i = indexes.Length; --i >= 0; )
            {
                if (indexes[i] is int intValue) {
                   str = str.Replace( $"[#{i}]", $"[{intValue}]" );
                   continue;
                }
                str = str.Replace( $"[#{i}]", $"['{indexes[i]}']" );
            }
        }
        // remove any left over tokens
        return str.Replace("#", "");
    }
