    Public Class PopupBox
        Inherits ToolStripDropDown
    
        Private mHost As ToolStripControlHost = Nothing
        Public ReadOnly Property Host As ToolStripControlHost
            Get
                Return mHost
            End Get
        End Property
    
        Public Sub New(content As Control)
            MyBase.New()
    
            Me.ResizeRedraw = True
            Me.Margin = Padding.Empty
            Me.Padding = Padding.Empty
            Me.AutoSize = True
    
            Me.mHost = New ToolStripControlHost(content)
    
            Me.mHost.Margin = Padding.Empty
            Me.mHost.Padding = Padding.Empty
            Me.mHost.AutoSize = True
    
            Me.Items.Add(Me.mHost)
    
        End Sub
    
    End Class
