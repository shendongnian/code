    Public Class HigwayNameComparer
    Implements IEqualityComparer(Of Highway)
    Public Function Equals(ByVal x As Highway, ByVal y As Highway) As Boolean Implements IEqualityComparer(Of Highway).Equals
        Return x.Name = y.Name
    End Function
    Public Function GetHashCode(ByVal obj As Highway) As Integer Implements IEqualityComparer(Of Highway).GetHashCode
        Return obj.Name.GetHashCode()
    End Function
    End Class
