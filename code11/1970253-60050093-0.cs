using System.Diagnostics;
using System.Linq;
static class XUnitHelper
{
	internal static string FactDisplayName()
	{
		var frame = new StackFrame(1, true);
		var method = frame.GetMethod();
		var attribute = method.GetCustomAttributes(typeof(Xunit.FactAttribute), true).First() as Xunit.FactAttribute;
		return attribute.DisplayName;
	}
}
Inside your unit test method, call `XUnitHelper.FactDisplayName()`. Of course this won't work if there is any nesting - for example, if you call this helper in another method which is itself called from the unit test method decorated by `Fact`. To handle a case like that, you'd have to write more complicated code which traversed the stack (in fact, that's why the `1` is passed to the constructor of `StackFrame`; we want to skip past the stack information for the helper method itself).
