    public static class DumpExtension
    {
        public static dynamic dump = LINQPad.Util.CreateXhtmlWriter();
        public static T Dump<T>(this T objToDump)
        {
            dump.Write(objToDump);
            return objToDump;
        }
    }
