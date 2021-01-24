class Error
{
    string Message { get; set; }
    Seq<Error> ChildErrors { get; set; }
}
class Result
{
}
private static Either<Error, Result> GetResultForQuery(string query) =>
    throw new NotImplementedException();
Either<Error, Seq<Result>> GetResults(Seq<string> queries)
{
    Seq<Either<Error, Result>> internalResults = queries.Map(GetResultForQuery);
    return internalResults.Sequence();
}
Either<Error, Seq<Result>> GetResults2(Seq<string> queries) =>
    queries.Map(GetResultForQuery).Sequence();
GetResults2 is just a short version of GetResults.
