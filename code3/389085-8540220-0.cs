    Public Class Form1
    
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            Dim startIP As New anIP("192.168.0.1")
            Dim endIP As New anIP("192.168.1.1")
    
            For x As Integer = startIP.asNumber To endIP.asNumber
                Dim foo As New anIP(x)
                Debug.WriteLine(foo.asString)
            Next
        End Sub
    
        Class anIP
            Property asNumber As Integer
            Property asAddr As Net.IPAddress
            Property asBytes As Byte()
            Property asString As String
    
            Public Sub New(ipString As String)
                Try
                    Me.asAddr = Net.IPAddress.Parse(ipString)
                    Me.asBytes = Me.asAddr.GetAddressBytes
                    Array.Reverse(Me.asBytes)
                    Me.asNumber = BitConverter.ToInt32(Me.asBytes, 0)
                Catch ex As Exception
                    Throw
                End Try
            End Sub
    
            Public Sub New(ipNumber As Integer)
                Me.asBytes = BitConverter.GetBytes(ipNumber)
                Array.Reverse(Me.asBytes)
                Me.asAddr = New Net.IPAddress(Me.asBytes)
                Me.asString = Me.asAddr.ToString
            End Sub
        End Class
    End Class
