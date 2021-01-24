    [Cmdlet("Lookup", "Aliases")]
    public class LookupAliases: PSCmdlet 
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = "1",
            HelpMessage = "Indicates the help message")]
        public string FirstArgument{ get; set; }
        protected override void ProcessRecord()
        {
            // write your process here.
            base.ProcessRecord();
        }
    }
In powershell, you will need to import this dll that you created above (Compile Solution) and run in powershell
Lookup-Aliases -FirstArugment "value"
If you are looking to run powershell commands inside c#,
    Runspace runSpace = RunspaceFactory.CreateRunspace();
    runSpace.Open();
    Pipeline pipeline = runSpace.CreatePipeline();
    string script = "your powershell script here";
    pipeline.Commands.AddScript(script);
    Collection<PSObject> output = pipeline.Invoke();
