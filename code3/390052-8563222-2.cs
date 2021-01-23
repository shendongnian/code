    <ComClass(ComRegistrar.ClassId, ComRegistrar.InterfaceId, ComRegistrar.EventsId>
    Public Class ComRegistrar
    
       Private Shared ReadOnly _eventHandlers As New Dictionary(Of String, List(Of IEventHandler))
    
    
       ' This is called by .NET code to fire events to VB6
       Public Shared Sub FireEvent(ByVal eventName As String, ByVal sender As Object, ByVal e As Object)
            For Each eventHandler In _eventHandlers(eventName)
                    eventHandler.OnEvent(sender, e)
            Next
       End Sub
    
       Public Sub RegisterHandler(ByVal eventName As String, ByVal handler As IEventHandler)
            Dim handlers as List(Of IEventHandler)
            If Not _eventHandlers.TryGetValue(eventName, handlers)
                 handlers = New List(Of IEventHandler)
                 _eventHandlers(eventName) = handlers
            End If
            handlers.Add(handler)
       End Sub
    
    End Class
