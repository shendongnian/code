    Public Partial Class MainWindow
    	Public Sub New()
    		InitializeComponent()
    	End Sub
    
    	Protected Overrides Sub OnSourceInitialized(e As EventArgs)
    		MyBase.OnSourceInitialized(e)
    
    		Dim handle As IntPtr = New WindowInteropHelper(Me).Handle
    		HwndSource.FromHwnd(handle).AddHook(New HwndSourceHook(AddressOf Me.WindowProc))
    	End Sub
    
    	Private Const WM_SIZING As Integer = &H214
    	Private Const WM_EXITSIZEMOVE As Integer = &H232
    	Private Function WindowProc(hwnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr, ByRef handled As Boolean) As IntPtr
    		Select Case msg
    			Case WM_SIZING
    				Me.firstColumn.ClearValue(ColumnDefinition.MinWidthProperty)
    				Exit Select
    			Case WM_EXITSIZEMOVE
    				Me.firstColumn.MinWidth = Me.firstColumn.ActualWidth
    				Me.SizeToContent = System.Windows.SizeToContent.WidthAndHeight
    				Exit Select
    		End Select
    
    		Return IntPtr.Zero
    	End Function
    
    End Class
