    public abstract class AbstractQueryHandler<TQuery, TQueryResult>
        where TQuery : Query<TQueryResult>
        where TQueryResult : class, new()
    {
        public Task<Result<TQueryResult>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return HandleQuery(request);
            }
            catch (Exception e)
            {
                return Task.FromResult(Result<TQueryResult>.Failure(new TQueryResult(), GetFailureMessage(e)));
            }
        }
        public abstract Task<Result<TQueryResult>> HandleQuery(TQuery request);
        private static string GetFailureMessage(Exception e)
        {
            return "There was an error while executing query: \r\n" + e.Message;
        }
    }
    public class BasicQueryHandler : AbstractQueryHandler<BasicQuery, ExampleDto>
    {
        public override Task<Result<ExampleDto>> HandleQuery(BasicQuery request)
        {
            return Task.FromResult(Result<ExampleDto>.Success(new ExampleDto() { Name = "Result Name" }));
        }
    }
