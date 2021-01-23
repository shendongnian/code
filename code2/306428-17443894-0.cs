     private static readonly List<byte[]> SPECIAL_TAGS = new List<byte[]>
                                                                {
                                                                    Encoding.ASCII.GetBytes("script"),
                                                                    Encoding.ASCII.GetBytes("style"),
                                                                    Encoding.ASCII.GetBytes("noscript")
                                                                };
        private static readonly List<byte[]> SPECIAL_TAGS_CLOSE = new List<byte[]>
                                                                      {
                                                                          Encoding.ASCII.GetBytes("/script"),
                                                                          Encoding.ASCII.GetBytes("/style"),
                                                                          Encoding.ASCII.GetBytes("/noscript")};
    public static string StripTagsCharArray(string source, bool toLowerCase)
        {
            var array = new char[source.Length];
            var arrayIndex = 0;
            var inside = false;
            var haveSpecialTags = false;
            var compareIndex = -1;
            var singleQouteMode = false;
            var doubleQouteMode = false;
            var matchMemory = SetDefaultMemory(SPECIAL_TAGS);
            for (int i = 0; i < source.Length; i++)
            {
                var let = source[i];
                if (inside && !singleQouteMode && !doubleQouteMode)
                {
                    compareIndex++;
                    if (haveSpecialTags)
                    {
                        var endTag = CheckSpecialTags(let, compareIndex, SPECIAL_TAGS_CLOSE, ref matchMemory);
                        if (endTag) haveSpecialTags = false;
                    }
                    if (!haveSpecialTags)
                    {
                        haveSpecialTags = CheckSpecialTags(let, compareIndex, SPECIAL_TAGS, ref matchMemory);
                    }
                }
                if (haveSpecialTags && let == '"')
                {
                    doubleQouteMode = !doubleQouteMode;
                }
                if (haveSpecialTags && let == '\'')
                {
                    singleQouteMode = !singleQouteMode;
                }
                if (let == '<')
                {
                    matchMemory = SetDefaultMemory(SPECIAL_TAGS);
                    compareIndex = -1;
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (inside) continue;
                if (char.IsDigit(let)) continue; 
                if (haveSpecialTags) continue;
                array[arrayIndex] = toLowerCase ? Char.ToLowerInvariant(let) : let;
                arrayIndex++;
            }
            return new string(array, 0, arrayIndex);
        }
        private static bool[] SetDefaultMemory(List<byte[]> specialTags)
        {
            var memory = new bool[specialTags.Count];
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = true;
            }
            return memory;
        }
