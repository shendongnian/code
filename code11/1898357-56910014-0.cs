public interface IForTenant
{
    string TenantId { get; }
}
You'll need a DB Connection Factory that takes tenant id as an argument to return an IDbConnection instance. Then you create a request filter, that checks if a request is of type IForTenant and get the correct IDbConnection instance from the aforementioned factory.
