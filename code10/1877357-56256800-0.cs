    private IElasticClient ElasticClient(IConfiguration _config, string defaultIndex)
    {
      var settings = new ConnectionSettings(new Uri(_config.GetSection("Search:Url").Value))
        .BasicAuthentication(_config.GetSection("Search:User").Value, _config.GetSection("Search:Password").Value)
        .DefaultIndex(_config.GetSection(defaultIndex).Value);
      //settings.DefaultFieldNameInferrer(p => p.ToUpper(CultureInfo.CurrentCulture));
      //Enable ElasticSearch Debugging
      settings.PrettyJson().DisableDirectStreaming();
      return new ElasticClient(settings);
    }
