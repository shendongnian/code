public class Proxy : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
}
public static class Extentsions
{
	public static EventInfo GetTargetEventInfo1<T>(this T source, Action<T> action) 
	{
		return GetTargetEventInfo(action);
	}
	
	static EventInfo GetTargetEventInfo(Delegate d)
	{
		'''''''
	}	
}
class Program
{
	static void Main(string[] args)
	{			
		var proxy = new Proxy();
		var eventInfo = proxy.GetEventInfo(x => x.PropertyChanged += null);
	}
}
here il would be like
0000 : ldarg.1
0001 : ldnull
0002 : callvirt instance System.Void ConsoleApp1.Proxy::add_PropertyChanged()
0007 : nop
0008 : ret
the result i want is 
{System.ComponentModel.PropertyChangedEventHandler PropertyChanged}
    AddMethod: {Void add_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler)}
    Attributes: None
    CustomAttributes: Count = 0
    DeclaringType: {Name = "Proxy" FullName = "ConsoleApp1.Proxy"}
    EventHandlerType: {Name = "PropertyChangedEventHandler" FullName = "System.ComponentModel.PropertyChangedEventHandler"}
    IsMulticast: true
    IsSpecialName: false
    MemberType: Event
    MetadataToken: 335544321
    Module: {ConsoleApp1.exe}
    Name: "PropertyChanged"
    RaiseMethod: null
    ReflectedType: {Name = "Proxy" FullName = "ConsoleApp1.Proxy"}
    RemoveMethod: {Void remove_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler)}
same thing from moq you will see
var mock = new Mock<IFoo> { DefaultValue = DefaultValue.Mock };
mock.Raise(x => x.Event += null, EventArgs.Empty);
public interface IFoo
{				
	event EventHandler Event;
}
if you step inside moq, you will found code, moq using CreateInterfaceProxyWithoutTarget from Castle.Core
var expression = ExpressionReconstructor.Instance.ReconstructExpression(action, mock.ConstructorArguments);
var parts = expression.Split();
here stored in parts is what i want. but need some more readable solution for developer.
