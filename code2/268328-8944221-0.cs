      Implements IDisposable 'Code is implemented automatically
      Public Sub New()
    
            ' This call is required by the designer.
            InitializeComponent()
    
            ' Add any initialization after the InitializeComponent() call.
            AddHandler Me.Dispatcher.ShutdownStarted, AddressOf Me_HasShutDownStarted
    
        End Sub
    
        
        Private Sub Me_HasShutDownStarted(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.disposedValue = False Then Call Me.Dispose()
        End Sub
