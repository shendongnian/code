    Public Class SignalRHub
        Inherits Hub
        Private Shared hubContext As IHubContext = GlobalHost.ConnectionManager.GetHubContext(Of SignalRHub)()
        Public Sub SendToAll(ByVal msg As String)
            hubContext.Clients.All.addNewMessageToPage(msg)
        End Sub
        Public Shared Sub SendToUser(ByVal user As String, ByVal msg As String)
            hubContext.Clients.Group(user).addNewMessageToPage(msg)
        End Sub
        Public Overrides Function OnConnected() As Task
            Dim name As String = Context.User.Identity.Name
            Groups.Add(Context.ConnectionId, name)
            Return MyBase.OnConnected()
        End Function
    End Class
