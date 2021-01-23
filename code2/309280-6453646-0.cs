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
