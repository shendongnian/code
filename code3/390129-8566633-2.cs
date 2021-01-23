    Public Class LookupListCollection
        Inherits System.Collections.Generic.List(Of LookupList)
    
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal ParamArray aItems As LookupList())
            Me.New()
            If aItems IsNot Nothing Then
                Me.AddRange(aItems)
            End If
        End Sub
    
    End Class
