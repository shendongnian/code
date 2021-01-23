vb
Imports System.Runtime.InteropServices
Namespace Mumble
    <ComVisible(True)> _
    <Guid("2352FDD4-F7C9-443a-BC3F-3EE230EF6C1B")> _
    <InterfaceType(ComInterfaceType.InterfaceIsDual)> _
    Public Interface IExample
        <DispId(0)> _
        Property Indexer(ByVal index As Integer) As Integer
        <DispId(1)> _
        Property SomeProperty(ByVal index As Integer) As String
    End Interface
End Namespace
Note the use of `<DispId>`, dispid 0 is special, it is the default property of an interface.  This corresponds to the indexer in the C# language.
All you need VB.NET for is the declaration, you can still write the *implementation* of the interface in the C# language. Project + Add Reference, Projects tab and select the VB.NET project. Make it look similar to this:
cs
using System;
using System.Runtime.InteropServices;
namespace Mumble {
	[ComVisible(true)]
	[Guid("8B72CE6C-511F-456e-B71B-ED3B3A09A03C")]
	[ClassInterface(ClassInterfaceType.None)]
    public class Implementation : ClassLibrary2.Mumble.IExample {
        public int get_Indexer(int index) {
            return index;
    	}
    	public void set_Indexer(int index, int Value) {
    	}
        public string get_SomeProperty(int index) {
            return index.ToString();
        }
        public void set_SomeProperty(int index, string Value) {
        }
    }
}
You need to run Tlbexp.exe on *both* the VB.NET and the C# assembly to generate the type libraries. The C# one with the implementation includes the VB.NET one.
To get the interface to derive from IUnknown instead of IDispatch, edit the interface declaration.  Remove the DispId attributes and use `ComInterfaceType.InterfaceIsUnknown`.
