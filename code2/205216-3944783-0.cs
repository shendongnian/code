    Public Class MessageService
    	Implements IMessage
    	Private Shared ReadOnly subscribers As New List(Of IMessageCallback)()
    
    	'The code in this AddMessage method is what I'd like to see re-written in VB...
    	Public Sub AddMessage(message As String)
    
    		subscribers.ForEach(Function(callback As IMessageCallback) Do
    			If DirectCast(callback, ICommunicationObject).State = CommunicationState.Opened Then
    				callback.OnMessageAdded(message, DateTime.Now)
    			Else
    				subscribers.Remove(callback)
    			End If
    		End Function)
    	End Sub
    
    	Public Function Subscribe() As Boolean
    		Try
    			Dim callback As IMessageCallback = OperationContext.Current.GetCallbackChannel(Of IMessageCallback)()
    			If Not subscribers.Contains(callback) Then
    				subscribers.Add(callback)
    			End If
    			Return True
    		Catch
    			Return False
    		End Try
    	End Function
    
    	Public Function Unsubscribe() As Boolean
    		Try
    			Dim callback As IMessageCallback = OperationContext.Current.GetCallbackChannel(Of IMessageCallback)()
    			If Not subscribers.Contains(callback) Then
    				subscribers.Remove(callback)
    			End If
    			Return True
    		Catch
    			Return False
    		End Try
    	End Function
    End Class
