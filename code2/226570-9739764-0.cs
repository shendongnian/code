    Public Shared Function ListItemType(ListType As System.Type) As System.Type
      If Not ListType.IsGenericType Then
        If ListType.BaseType IsNot Nothing AndAlso ListType.BaseType.IsGenericType Then
          Return ListItemType(ListType.BaseType)
        End If
      Else
        Return ListType.GetGenericArguments.Single
      End If
    End Function
