    Public Sub AddMessage(ByVal message As String) Implements IMessage.AddMessage
        subscribers.ForEach(Sub(callback As IMessageCallback)
                                If DirectCast(callback, ICommunicationObject).State = CommunicationState.Opened Then
                                    callback.OnMessageAdded(message, DateTime.Now)
                                Else
                                    subscribers.Remove(callback)
                                End If
                            End Sub)
    End Sub
