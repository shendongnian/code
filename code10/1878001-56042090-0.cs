    public class Foo
    {
        private readonly IOptions<AppSetings> _settings;
        public Foo(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
        public void Bar()
        {
            var apiUrl = _settings.Value.ApiUrl;
            // do something;
        }
    }
