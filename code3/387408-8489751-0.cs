    private static readonly Dictionary<Guid, string> _knownImageFormats =
                (from p in typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public)
                 where p.PropertyType == typeof(ImageFormat)
                 let value = (ImageFormat)p.GetValue(null, null)
                 select new { Guid = value.Guid, Name = value.ToString() })
                .ToDictionary(p => p.Guid, p => p.Name);
    
    static string GetImageFormatName(ImageFormat format)
    {
        string name;
        if (_knownImageFormats.TryGetValue(format.Guid, out name))
            return name;
        return null;
    }
