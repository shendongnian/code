    public Guid(string g)
        {
            if (g == null)
            {
                throw new ArgumentNullException("g");
            }
            this = Empty;
            GuidResult result = new GuidResult();
            result.Init(GuidParseThrowStyle.All);
            if (!TryParseGuid(g, GuidStyles.Any, ref result))
            {
                throw result.GetGuidParseException();
            }
            this = result.parsedGuid;
        }
    
        public static Guid Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            GuidResult result = new GuidResult();
            result.Init(GuidParseThrowStyle.AllButOverflow);
            if (!TryParseGuid(input, GuidStyles.Any, ref result))
            {
                throw result.GetGuidParseException();
            }
            return result.parsedGuid;
        }
