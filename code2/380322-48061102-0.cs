    public static class RegisterFilters
    {
        public static void Execute(HttpConfiguration configuration)
        {
            configuration.Services.Add(typeof(IExceptionLogger), new WebExceptionLogger());
        }
    }
