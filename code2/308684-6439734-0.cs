    ModuleType Name                      ExportedCommands
    ---------- ----                      ----------------
    Binary     ClassLibrary2             Get-RemedyXml
  
    using System.Management.Automation;
    
    namespace ClassLibrary1
    {
        [Cmdlet(VerbsCommon.Get, "RemedyXml")]
        public class Class1 : PSCmdlet
        {
            [Parameter(Position = 0, Mandatory = true)] 
            public string TicketID;
    
            protected override void ProcessRecord()
            {
                WriteObject(TicketID);
            }
        }
    }
