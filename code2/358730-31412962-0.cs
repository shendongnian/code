    ''' <summary>
    ''' Trim all NOT ReadOnly String properties of the given object
    ''' </summary>
    <Extension()>
    Public Function TrimStringProperties(Of T)(ByVal input As T) As T
        Dim stringProperties = input.GetType().GetProperties().Where(Function(p) p.PropertyType = GetType(String) AndAlso p.CanWrite)
        For Each stringProperty In stringProperties
            Dim currentValue As String = Convert.ToString(stringProperty.GetValue(input, Nothing))
            If currentValue IsNot Nothing Then
                stringProperty.SetValue(input, currentValue.Trim(), Nothing)
            End If
        Next
        Return input
    End Function
