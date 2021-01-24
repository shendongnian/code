    using System.Management.Automation;
    namespace MyCmdlets
    {
        [Cmdlet(VerbsCommon.Add, "Set"), OutputType(typeof(Set))]
        public class AddSetCmdlet : PSCmdlet
        {
            [Parameter(ValueFromPipeline = true, Mandatory = true)]
            public Suite Suite { get; set; }
            [Parameter(Position = 0, Mandatory = true)]
            public string Type { get; set; }
            [Parameter(Position = 1, Mandatory = true)]
            public string Description { get; set; }
            protected override void ProcessRecord() {
                var set = new Set(Type, Description);
                Suite.Sets.Add(set);
                WriteObject(set);
            }
        }
        [Cmdlet(VerbsCommon.Add, "Option"), OutputType(typeof(Option))]
        public class AddOptionCmdlet : PSCmdlet
        {
            [Parameter(ValueFromPipeline = true, Mandatory = true)]
            public Set Set { get; set; }
            [Parameter(Position = 0, Mandatory = true)]
            public string Color { get; set; }
            [Parameter(Position = 1, Mandatory = true)]
            public string Place { get; set; }
            protected override void ProcessRecord() {
                var option = new Option(Color, Place);
                Set.Options.Add(option);
                WriteObject(Set);
            }
        }
    }
