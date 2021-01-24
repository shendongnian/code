public interface IImportProcessor
{
    void Process(IImportModel model);
}
----
The material processor should implement `Process` that takes the interface, not a concrete class. Otherwise it a) doesn't meet the contract and b) you getting rid of the benefits of interfaces :).
public class MaterialImportProcessor : IImportProcessor
{
    public void Process(IImportModel model)
    {
        // do some logic here
    }
}
