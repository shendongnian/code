    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _controller = new HIDController(Me.Handle)
        AddHandler _controller.Plugged, AddressOf Me.OnPlugged
        'similarly for other events
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If _controller IsNot Nothing Then _controller.Dispose()
    End Sub
