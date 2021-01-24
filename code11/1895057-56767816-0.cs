c#
interface IRule<TEntity>
{
    string Rule { get; }
    string SaveToTable { get; }
    ReportEntity Handle(TableEntity entity);
    TableQuery<TEntity> GetTableQuery();
}
Then, in your `IRule<TEntity>` implementations add the correct entity.  Eg for `AddressRule`.
c#
    public class AddressRule : IRule<ContractAcccount>
    {
        public string TableName => "ContractAccount";
        public string Rule => "Email cannot be empty";
        public string SaveToTable => "XXXX";
        public ReportEntity Handle(TableEntity entity)
        {
            var contract = entity as ContractAccount;
            if(contract == null)
            {
                throw new Exception($"Expecting entity type {TableName}, but passed in invalid entity");
            }
            if (string.IsNullOrWhiteSpace(contract.Address))
            {
                var report = new ReportEntity(this.Rule, contract.UserId, contract.AccountNumber, contract.ContractNumber)
                {
                    PartitionKey = contract.UserId,
                    RowKey = contract.AccountNumber
                };
                return report;
            }
            return null;
        }
        public TableQuery<ContractAccount> GetTableQuery()
        {
            return new TableQuery<ContractAccount>();
        }
    }
Now, in your `Validate` method, you can use the `GetTableQuery` method from the `IRule`.
c#
public async void Validate(CloudStorageAccount storageAccount)
{
    var tableClient = storageAccount.CreateCloudTableClient();
        //.....
        var query = rule.GetTableQuery();
        //...
        var rows = await tableToBeValidated.ExecuteQuerySegmentedAsync(query, token);
    }
    //...
}
