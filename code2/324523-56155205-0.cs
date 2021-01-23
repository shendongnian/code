    Event IsMinimizedChanged As EventHandler
    Private mIsMinimized As Boolean
    
    Protected Overrides Sub OnChildDesiredSizeChanged(child As UIElement)
        MyBase.OnChildDesiredSizeChanged(child)
        If TypeOf child Is Grid Then
            If Not mIsMinimized = IsMinimized Then
                RaiseEvent IsMinimizedChanged(Me, EventArgs.Empty)
                mIsMinimized = IsMinimized
            End If
        End If
    End Sub
