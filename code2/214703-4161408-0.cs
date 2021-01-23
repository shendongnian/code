    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
                If obj Is Nothing Or Not Me.GetType() Is obj.GetType() Then
                    Return False
                End If
                Dim u As User = CType(obj, TUser)
                Return Me.UserId = u.UserId
    End Function
