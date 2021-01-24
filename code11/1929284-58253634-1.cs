IEnumerable<ReportContractVM> result = contracts.Select(
            x => new ReportContractVM
                     {
                       ContactId = x.ContractId,
                       ContractName = x.ContractName
                     }
            );
to this:
List<ReportContractVM> list = contracts
    .Select( x => new ReportContractVM { ContractId = x.ContractId, ContractName = x.ContractName  } )
    .ToList();
Also, change your `ActionResult<T>` to use `IReadOnlyList<T>` instead of `IEnumerable<T>` which will help ensure you always return a materialized list instead of a possibly non-materialized enumerator:
public class SomeController : ControllerBase
{
    public ActionResult<IReadOnlyList<ReportContractVM>> Get()
    {
    }
}
BTW, I've been having problems with `ActionResult<T>` not working well with generics and in `async Task<ActionResult<T>>` actions so I personally prefer to do this, but YMMV:
public class SomeController : ControllerBase
{
    [Produces( typeof( IReadOnlyList<ReportContractVM> ) )
    public IActionResult Get()
    {
    }
    // if async:
    [Produces( typeof( IReadOnlyList<ReportContractVM> ) )
    public async Task<IActionResult> Get()
    {
    }
}
