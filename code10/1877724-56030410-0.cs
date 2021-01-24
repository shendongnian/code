`
public class ScriptMain : UserComponent
{
    List<AvroRecord> CounterpartsRowList = new List<AvroRecord>(); //This line was the problem
    public ScriptMain()
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    public System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        string path = @"D:\BDS\clientscoredata\ClientScoreDataSsis";
        if (args.Name.Contains("Microsoft.Hadoop.Avro"))
        {
            return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "Microsoft.Hadoop.Avro.dll"));
        }
        if (args.Name.Contains("Newtonsoft.Json"))
        {
            return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "Newtonsoft.Json.dll"));
        }
        return null;
    }
    /// <summary>
    /// This method is called once, before rows begin to be processed in the data flow.
    ///
    /// You can remove this method if you don't need to do anything here.
    /// </summary>
    public override void PreExecute()
    {
        base.PreExecute();
        abc = new List<AvroRecord>(); // initialization moved here
`
So basically the the initialization of abc moved to the PreExecute method instead of right when it is defined.
