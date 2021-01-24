public abstract class ModelTest<TModel, TEntity>
    where TModel : Model<TEntity>, new()
    where TEntity : IEntity
{...}
public class ServiceTicketModelTest
    : ModelTest<ServiceTicketModel, ServiceTicket>
    , IDisposable
{...}
