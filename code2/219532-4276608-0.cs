     Dim properties() As PropertyInfo = Me.GetType.GetProperties(BindingFlags.Public Or BindingFlags.Instance)
                If properties IsNot Nothing AndAlso properties.Length > 0 Then
                    properties = properties.Except(baseProperties)
                    For Each p As PropertyInfo In properties
                        If p.Name <> "" Then
                            p.SetValue(Me, Date.Now, Nothing)  'user p.GetValue in your case
                        End If
                    Next
                End If
