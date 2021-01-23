    public string GetProtocolHeaderValue(string name, IHeaderParser parser)
    {
        IHeader header = parser.GetProtocolHeader(name);
        return parser.HeaderValue(IHeader header);
    }
