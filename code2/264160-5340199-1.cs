    public static ICommon CreateCommon(FileLine line)
    {
         // assume map is visible
         var producer = map[line.Type];
         return producer();
    }
