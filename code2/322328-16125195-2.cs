    Imports System.Windows.Forms
    
    Public Class MyClass: Inherits NativeWindow
	Private piFormHandle As Integer = 0
	Sub New()
		Me.CreateHandle(New CreateParams)
		piFormHandle = CInt(Me.Handle)
	End Sub
	Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
		Select Case (m.Msg)
			Case MyMessage
		End Select
		MyBase.WndProc(m)
	End Sub
    End Class
