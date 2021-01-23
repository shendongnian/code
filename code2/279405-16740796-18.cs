    public class TheCompanyContext : Entities
    {
            // Please check your entity store name
            [EdmFunction("TheCompanyDbModel.Store", "RegExpLike")]
            public bool RegExpLike(string text, string pattern, int options)
            {
                throw new NotSupportedException("Direct calls are not supported.");
            }
    }
