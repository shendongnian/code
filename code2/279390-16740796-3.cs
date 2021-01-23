    public class TheCompanyContext : Entities
    {
            [EdmFunction("TheCompanyDbModel.Store", "RegExpLike")]
            public bool RegExpLike(string text, string pattern, int options)
            {
                throw new NotSupportedException("Direct calls are not supported.");
            }
    }
