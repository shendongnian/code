    Public Class ImageButton
        Public Property ImagePath As String
        Public Property ImageName As String
    
        Public Sub New()
    
        End Sub
    
        Public Sub New(ByVal Path As String, ByVal Name As String)
            Me.ImagePath = Path
            Me.ImageName = Name
        End Sub
    End Class
