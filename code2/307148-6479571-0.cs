    Public Class TSQueue(Of T)
    
    	Private q As New Queue(Of T)
    	Public Property threshold As Integer = 100
    	Public Event ThresholdHit As EventHandler(Of EventArgs)
    
    	Public Sub EnqueueSafe(value As T)
    		Dim notify As Boolean = False
    		SyncLock q
    			q.Enqueue(value)
    			If q.Count >= threshold Then
    				notify = True
    			End If
    		End SyncLock
    		If notify Then
    			RaiseEvent ThresholdHit(Me, EventArgs.Empty)
    		End If
    	End Sub
    
    	Public Function DequeueSafe() As T
    		SyncLock q
    			Return q.Dequeue()
    		End SyncLock
    	End Function
    
    	Public Function DequeueAllSafe() As T()
    		Dim out() As T
    		SyncLock q
    			out = q.ToArray()
    			q.Clear()
    		End SyncLock
    		Return out
    	End Function
    
    	Public Function CountSafe() As Integer
    		SyncLock q
    			Return q.Count
    		End SyncLock
    	End Function
    
    End Class
