        public static string CustomReplace(string srcText, string toFind, string toReplace, bool matchCase, bool replace0nce)
        {
            StringComparison sc = StringComparison.OrdinalIgnoreCase;
            if (matchCase)
                sc = StringComparison.Ordinal;
            int pos;
            while ((pos = srcText.IndexOf(toFind, sc)) > -1)
            {
                srcText = srcText.Remove(pos, toFind.Length);
                srcText = srcText.Insert(pos, toReplace);
                if (replace0nce)
                    break;
            }
            return srcText;
        }
