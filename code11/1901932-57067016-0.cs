    public static async Task<ConnectionInfo> LoadConnection(CloudTable cloudTable, string container) {
        var filter = TableQuery.GenerateFilterCondition("container", QueryComparisons.Equal, container);
        var query = new TableQuery<SftpServerConnectionsModel>().Where(filter);
        var querySegment = await cloudTable.ExecuteQuerySegmentedAsync(query, null);
        var entity = querySegment.FirstOrDefault();
        if(entity != null) {
            return new ConnectionInfo(entity.uri, entity.user, new AuthenticationMethod[]{
            new PasswordAuthenticationMethod(entity.user,entity.password)});
        }
        return default(ConnectionInfo);
    }
