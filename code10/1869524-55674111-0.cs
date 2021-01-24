    Imports System.IO.Ports
    Public Class SerialCom
        Dim WithEvents SP As New SerialPort("COM5", 9600)
        Private Sub SerialCom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SP.Open()
        End Sub
    
        Private Sub SP_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SP.DataReceived
            Dim dataR As String = SP.ReadExisting
            Me.Invoke(New updateText(AddressOf updateText_s), dataR)
        End Sub
    
        Public Delegate Sub updateText(ByVal line As String)
        Sub updateText_s(ByVal line As String)
            txtCom.AppendText(line)
        End Sub
    
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            SP.Write("Welcome")
        End Sub
    End Class
