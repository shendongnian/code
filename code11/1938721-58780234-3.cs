    using System.Management.Automation;
    namespace MyCmdlets  
    {
        [Cmdlet(VerbsCommon.Add, "Set"), OutputType(typeof(Set))]
        public class AddSetCmdlet : PSCmdlet 
        {
            [Parameter(ValueFromPipeline = true), ValidateNotNull]
            public Suite Suite { get; set; }
            [Parameter]
            public string Type { get; set; }
            [Parameter]
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
            [Parameter(ValueFromPipeline = true), ValidateNotNull]
            public Set Set { get; set; }
            [Parameter]
            public string Color { get; set; }
            [Parameter]
            public string Place { get; set; }
            protected override void ProcessRecord() {
                var option = new Option(Color, Place);
                Set.Options.Add(option);
                WriteObject(Set);
            }
        }
    }
