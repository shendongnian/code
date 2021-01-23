    Imports System.Collections.Generic
    Imports System.Linq
    Imports System.Text
    Imports System.Net.Sockets
    Imports System.Diagnostics
    Imports System.Net
    Imports System.Threading
    Namespace ConsoleApplication1
    	Class Program
    		Private Shared Sub Main(args As String())
    			Dim Address As String = "*PUT IP ADDRESS HERE WHERE UDP SERVER IS*"
    			Dim UDPPort As Integer = *PUT UDP SERVER PORT HERE*
    			Dim _UdpRedirect As New UdpRedirect() With { _
    				Key ._address = Address, _
    				Key ._Port = UDPPort _
    			}
    			Dim _Thread As New Thread(AddressOf _UdpRedirect.Connect)
    			_Thread.Name = "UDP"
    			_Thread.Start()
    
    			Dim TCPPort As Integer = *PUT TCP SERVER PORT HERE*
    			Dim _TcpRedirect As New TcpRedirect(Address, TCPPort)
    		End Sub
    	End Class
    	Class UdpRedirect
    		Public _address As String
    		Public _Port As Integer
    		Public Sub New()
    		End Sub
    
    		Public Sub Connect()
    			Dim _UdpClient As New UdpClient(_Port)
    			Dim LocalPort As System.Nullable(Of Integer) = Nothing
    			While True
    				Dim _IPEndPoint As IPEndPoint = Nothing
    				Dim _bytes As Byte() = _UdpClient.Receive(_IPEndPoint)
    				If LocalPort Is Nothing Then
    					LocalPort = _IPEndPoint.Port
    				End If
    				Dim Local As Boolean = IPAddress.IsLoopback(_IPEndPoint.Address)
    				Dim AddressToSend As String = Nothing
    				Dim PortToSend As Integer = 0
    				If Local Then
    					AddressToSend = _address
    					PortToSend = _Port
    				Else
    					AddressToSend = "127.0.0.1"
    					PortToSend = LocalPort.Value
    				End If
    				_UdpClient.Send(_bytes, _bytes.Length, AddressToSend, PortToSend)
    			End While
    		End Sub
    	End Class
    	Class TcpRedirect
    		Public Sub New(_address As String, _Port As Integer)
    
    			Dim _TcpListener As New TcpListener(IPAddress.Any, _Port)
    			_TcpListener.Start()
    			Dim i As Integer = 0
    			While True
    				i += 1
    				Dim _LocalSocket As TcpClient = _TcpListener.AcceptTcpClient()
    				Dim _NetworkStreamLocal As NetworkStream = _LocalSocket.GetStream()
    
    				Dim _RemoteSocket As New TcpClient(_address, _Port)
    				Dim _NetworkStreamRemote As NetworkStream = _RemoteSocket.GetStream()
    				Console.WriteLine(vbLf & "<<<<<<<<<connected>>>>>>>>>>>>>")
    				Dim _RemoteClient As New Client("remote" + i) With { _
    					Key ._SendingNetworkStream = _NetworkStreamLocal, _
    					Key ._ListenNetworkStream = _NetworkStreamRemote, _
    					Key ._ListenSocket = _RemoteSocket _
    				}
    				Dim _LocalClient As New Client("local" + i) With { _
    					Key ._SendingNetworkStream = _NetworkStreamRemote, _
    					Key ._ListenNetworkStream = _NetworkStreamLocal, _
    					Key ._ListenSocket = _LocalSocket _
    				}
    			End While
    		End Sub
    		Public Class Client
    			Public _ListenSocket As TcpClient
    			Public _SendingNetworkStream As NetworkStream
    			Public _ListenNetworkStream As NetworkStream
    			Private _Thread As Thread
    			Public Sub New(Name As String)
    				_Thread = New Thread(New ThreadStart(AddressOf ThreadStartHander))
    				_Thread.Name = Name
    				_Thread.Start()
    			End Sub
    			Public Sub ThreadStartHander()
    				Dim data As [Byte]() = New Byte(99998) {}
    				While True
    					If _ListenSocket.Available > 0 Then
    						Dim _bytesReaded As Integer = _ListenNetworkStream.Read(data, 0, _ListenSocket.Available)
    						_SendingNetworkStream.Write(data, 0, _bytesReaded)
    						Console.WriteLine("(((((((" + _bytesReaded + "))))))))))" + _Thread.Name + vbLf + ASCIIEncoding.ASCII.GetString(data, 0, _bytesReaded).Replace(CChar(7), "?"C))
    					End If
    					Thread.Sleep(10)
    				End While
    			End Sub
    
    		End Class
    	End Class
    End Namespace
