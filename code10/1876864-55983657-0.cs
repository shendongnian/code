    public sealed class CompositeApiCaller : ApiCaller
    {
        private const string SEPARATION_STRING = Environnement.NewLine;
        private ApiCaller[] _apiCallers;
        public CompositeApiCaller(params ApiCaller[] apiCallers)
        {
            _apiCallers = apiCallers;
        }
        public override string GetApiResultAsync()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < _apiCallers.Length; i++)
            {
                if (i > 0)
                    builder.Append(SEPARATION_STRING);
                builder.Append(apiCaller.GetApiResultAsync());
            }
            return builder.ToString();
        }
    }
