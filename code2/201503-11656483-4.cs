		For Each column As DataColumn In _dt.Columns
			CreateProperty(tb, column.ColumnName, column.DataType)
		Next
    
	Private Shared Sub setvalue(ByVal _obj As Object, ByVal _propName As String, ByVal _propValue As Object)
		Dim pi As PropertyInfo
		pi = _obj.GetType.GetProperty(_propName)
		If pi IsNot Nothing AndAlso pi.CanWrite Then
			If _propValue IsNot DBNull.Value Then
				pi.SetValue(_obj, _propValue, Nothing)
			Else
				Select Case pi.PropertyType.ToString
					Case "System.String"
						pi.SetValue(_obj, String.Empty, Nothing)
					Case Else
						'let the serialiser use javascript "null" value.
				End Select
			End If
		End If
	End Sub
