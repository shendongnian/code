    Public Shared Function GetPropertyValue(ByVal obj As Object, ByVal prop As String, Optional ByVal bindFlags As BindingFlags = BindingFlags.GetProperty Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance) As Object
            Dim objectType As Type = obj.GetType()
    
            Dim propInfo As PropertyInfo = objectType.GetProperty(prop, bindFlags)
            If propInfo Is Nothing Then
                propInfo = LookThroughtAllBaseProperties(objectType, prop, bindFlags)
            End If
    
            If propInfo Is Nothing Then
                Throw New Exception("Property: '" & prop & "' not found in: " & objectType.ToString)
            End If
            Return propInfo.GetValue(obj, Nothing)
        End Function
    
        Private Shared Function LookThroughtAllBaseProperties(ByVal objectType As Type, ByVal name As String, ByVal bindFlags As BindingFlags) As PropertyInfo
            Dim objType As Type = objectType
            While objType IsNot Nothing
                For Each availProp As PropertyInfo In objType.GetProperties(bindFlags)
                    If availProp.Name = name Then
                        Return availProp
                    End If
                Next
                objType = objType.BaseType
            End While
            Return Nothing
        End Function
