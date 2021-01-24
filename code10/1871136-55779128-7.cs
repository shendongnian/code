    public Interface ITableOps
    {
        Task WriteNewUser(UserModel user, List<GroupModel>, groups);
    }
    public class TableOps : ITableOps
    {
        public async Task WriteNewUser(UserModel user, List<GroupModel>, groups)
        {
            //...assume user table connection is created
            var entity = new DynamicTableEntity(partitionKey, rowKey);
            entity.Properties = TableEntity.Flatten(user, new OperationContext());
            await userTable.ExecuteAsync(TableOperation.Insert(user));
            //...assume group table connection is created
            groups.ForEach(async g =>
                {
                    var groupsEntity = new DynamicTableEntity(user.UserId, Guid.NewGuid().ToString());
                    groupsEntity.Properties = TableEntity.Flatten(g, new OperationContext());
                    await groupsTable.ExecuteAsync(TableOperation.Insert(groupsEntity));
                });
        }
