`c#
    protected void Application_Start()
    {
        HangfireJobsConfig.Register();
    }
    public class HangfireJobsConfig
    {
        public static void Register()
        {
            if (App1Config.RunHangfireService)
            {
                JobStorage.Current = new SqlServerStorage(App1Config.DefaultConnectionStringName.Split('=').Last());
                GlobalConfiguration.Configuration.UseConsole();
                RecurringJob.AddOrUpdate("RunImportSapInventoryHealexDataFile", () => RunImportSapInventoryHealexDataFile(null), Cron.MinuteInterval(App1Config.RunImportSapDataFileServiceMinuteInterval));
                //RecurringJob.AddOrUpdate("RunImportRpaHealexDataFile", () => RunImportRpaHealexDataFile(null), Cron.DayInterval(15));
                RecurringJob.AddOrUpdate("RunImportSalesOrgPricesHealexDateFile", () => RunImportSalesOrgPricesHealexDateFile(null), Cron.MinuteInterval(App1Config.RunImportSapDataFileServiceMinuteInterval));
            }
        }
        [AutomaticRetry(Attempts = 0, Order = 1)]
        public static void RunImportSalesOrgPricesHealexDateFile(PerformContext context)
        {
            ImportSapDataFileService.Import(new ImportSalesOrgPricesHealexDateFile(new ImportEtlFactory(), context).GetCommand());
        }
        [AutomaticRetry(Attempts = 0, Order = 2)]
        public static void RunImportSapInventoryHealexDataFile(PerformContext context)
        {
            ImportSapDataFileService.Import(new ImportSapInventoryHealexDataFile(new ImportEtlFactory(), context).GetCommand());
        }
        [AutomaticRetry(Attempts = 0, Order = 3)]
        public static void RunImportRpaHealexDataFile(PerformContext context)
        {
            ImportSapDataFileService.Import(new ImportRpaHealexDataFile(new ImportEtlFactory(), context).GetCommand());
        }
    }
`
