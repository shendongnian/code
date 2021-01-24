    public class SomeClass
    {
       public string SomeProp {get; set;}
       public string YourMCPField {get; set;}
       // make a SPECIAL FIELD... could be boolean, number setting, whatever flag
       // but in this case, I just have boolean
       public bool FieldContainsMCP { get { return YourMCPFieldContains( "MCP :"); }}
    }
