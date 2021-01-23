    Dictionary<Int32,Image> images = new Dictionary<Int32, Image>();
    // populated previously
    Int32 needle = GetIndexOfImage(newImage);
    if (!images.ContainsKey(needle))
      images.Add(needle, newImage);
