csharp
using System.Management.Automation;
namespace Test
{
    [Cmdlet(VerbsCommunications.Connect, "TestSystem")]
    public class VariableTest : PSCmdlet
    {
        private string _item;
        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }
        protected override void ProcessRecord()
        {
            Item = "FooBar";
        }
        protected override void EndProcessing()
        {
            SessionState.PSVariable.Set(new PSVariable(nameof(Item), Item, ScopedItemOptions.Private));
        }
    }
}
**Other cmdlet**
csharp
using System.Management.Automation;
namespace Test
{
    [Cmdlet(VerbsCommunications.Read, "TestVariable")]
    public class ReadVariable : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }
        protected override void ProcessRecord()
        {
            var test = SessionState.PSVariable.Get("Item");
            WriteObject(test.Value.ToString());
        }
    }
}
**Result**
powershell
PS C:\> Connect-TestSystem
PS C:\> Read-TestVariable
FooBar
