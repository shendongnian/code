c#
public partial class DataAdapter : BaseEntityDataAdapter, IDataAdapter {
    AppInsightsLogger _log = new AppInsightsLogger();
    private DataAdapter() : base("db") { }
    
    public static async Task<DataAdapter> ConstructAdapterAsync() {
        DataAdapter da = new DataAdapter();
        try {
            var conn = da.Database.Connection as System.Data.SqlClient.SqlConnection;
            conn.AccessToken = await (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/");
            return da;
        } catch (Exception ex) {
            da._log.LogError(ex);
            throw;
        }
    }
}
