public interface IImportProcessor
{
     void Process();
}
public class ImportModel1 { public string Name { get; set; }}
public class ImportProcessor1 : IImportProcessor
{
    private readonly ImportModel1 data;
    public ImportProcessor1(ImportModel1 data) { this.data = data;}
    public void Process() => Console.WriteLine($"My name is {data.Name}");
}
public class ImportModel2{ public int Age { get; set; }}
public class ImportProcessor2 : IImportProcessor
{
    private readonly ImportModel2 data;
    public ImportProcessor2(ImportModel2 data) { this.data = data;}
    public void Process() => Console.WriteLine($"My age is {data.Age}");
}
public enum EType {One = 1, Two = 2}
public class ImportProcessorFactory
{
    public IImportProcessor Get(EType type, string file) 
    {   
        switch (type)
        {
            case EType.One: return new ImportProcessor1(JsonConvert.DeserializeObject<ImportModel1>(file));
            case EType.Two: return new ImportProcessor2(JsonConvert.DeserializeObject<ImportModel2>(file));
        }
        throw new NotImplementedException("Unable to work with '{type}'");
    }
}
class Program
{
    public static void Main() 
    {
        var f = new ImportProcessorFactory();
        var data1 = (EType.One, "{ Name: 'Vlad' }");
        var p1 = f.Get(data1.Item1, data1.Item2 );
        Console.WriteLine(p1.GetType());
        p1.Process();
        var data2 = (EType.Two, "{ Age: '20' }");
        var p2 = f.Get(data2.Item1, data2.Item2 );
        Console.WriteLine(p2.GetType());
        p2.Process();
    }
}
## Output
ImportProcessor1
My name is Vlad
ImportProcessor2
My age is 20
# Update 1
Drop the model interface and make the processor take T
public interface IImportProcessor<T>
{
    void Process(T model);
}
With this setup things should hold together. 
public interface IImportProcessor<T>
{
    void Process(T model);
}
public class MaterialImportModel
{
    public string Name { get; set; }
}
public class MaterialImportProccessor : IImportProcessor<MaterialImportModel>
{
    public void Process(MaterialImportModel model)
    {
        // do some logic here
    }
}
public interface IImportProcessorFactory<T>
{
    IImportProcessor<T> Get();
}
public class ImportProcessorFactory : IImportProcessorFactory<MaterialImportModel>
{
    public IImportProcessor<MaterialImportModel> Get() => new MaterialImportProccessor();
}
----
*(Old answer)*
I think making `IImportProcessor` non generic would make your model much simpler and removed a whole class of problems.
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
