    var metrics = MetricsProvider.Instance.Metrics;
    SetMetricsAppTag(metrics, Assembly.GetExecutingAssembly().GetName().Name);   
   
    private static void SetMetricsAppTag(IMetricsRoot metricsRoot, string appTagValue)
    {
         if (!metricsRoot.Options.GlobalTags.ContainsKey("app"))
         {
               metricsRoot.Options.GlobalTags.Add("app", appTagValue);
         }
         else if (string.IsNullOrEmpty(metricsRoot.Options.GlobalTags["app"]) || metricsRoot.Options.GlobalTags["app"] == "unknown")
         {
               metricsRoot.Options.GlobalTags["app"] = appTagValue;
         }
    }
