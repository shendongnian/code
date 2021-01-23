    public static string MakeSafeFilename(string filename, string spaceReplace)
        {
            return MakeSafeFilename(filename, spaceReplace, false, false);
        }
        public static string MakeSafeUrlSegment(string text)
        {
            return MakeSafeUrlSegment(text, "-");
        }
        public static string MakeSafeUrlSegment(string text, string spaceReplace)
        {
            return MakeSafeFilename(text, spaceReplace, false, true);
        }
        public static string MakeSafeFilename(string filename, string spaceReplace, bool htmlDecode, bool forUrlSegment)
        {
            if (htmlDecode)
                filename = HttpUtility.HtmlDecode(filename);
            string pattern = forUrlSegment ? @"[^A-Za-z0-9_\- ]" : @"[^A-Za-z0-9._\- ]";
            string safeFilename = Regex.Replace(filename, pattern, string.Empty);
            safeFilename = safeFilename.Replace(" ", spaceReplace);
            return safeFilename;
        }
