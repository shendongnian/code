Dim fooObj As New Foo
Dim barObj As New Bar
fooObj.Value = 10
barObj.Value = 10
System.Diagnostics.Debug.WriteLine(barObj.Equals(fooObj))
System.Diagnostics.Debug.WriteLine(barObj.Equals(barObj))
System.Diagnostics.Debug.WriteLine(barObj.Equals(10))
System.Diagnostics.Debug.WriteLine(barObj.Equals(20))
System.Diagnostics.Debug.WriteLine(barObj.Equals("10"))
System.Diagnostics.Debug.WriteLine(barObj.Equals("20"))
System.Diagnostics.Debug.WriteLine(Object.Equals(barObj, 10))
Public Class Foo
    Public Value As Integer
End Class
Public Class Bar
    Public Value As Integer
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is Bar Then
            Dim compareBar As Bar = DirectCast(obj, Bar)
            Return MyClass.Value = compareBar.Value
        ElseIf TypeOf obj Is Foo Then
            Dim compareFoo As Foo = DirectCast(obj, Foo)
            Return MyClass.Value = compareFoo.Value
        ElseIf TypeOf obj Is Integer Then
            Dim compareInt As Integer = DirectCast(obj, Integer)
            Return MyClass.Value = compareInt
        ElseIf TypeOf obj Is String Then
            Dim compareString As Integer = DirectCast(obj, String)
            Return MyClass.Value.ToString() = compareString
        End If
        Return False
    End Function
End Class
