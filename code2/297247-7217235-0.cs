Public Interface IDoSomething
    Sub Dosomething()
End Interface
Structure MagicInvoker
    Implements IDoSomething, IDisposable
    Private holder As InvokerBase
    Private index As Integer
    Sub DoSomething() Implements IDoSomething.Dosomething
        holder.DoDoSomething(index)
    End Sub
    Shared Function Create(Of T As IDoSomething)(ByVal thing As T) As MagicInvoker
        Dim newInvoker As MagicInvoker
        newInvoker.holder = Invoker(Of T).HolderInstance
        newInvoker.index = Invoker(Of T).DoAdd(thing)
        Return newInvoker
    End Function
    Function Clone() As MagicInvoker
        Dim newHolder As New MagicInvoker
        newHolder.holder = Me.holder
        newHolder.index = Me.holder.DoClone(Me.index)
        Return newHolder
    End Function
    Private MustInherit Class InvokerBase
        MustOverride Sub DoDoSomething(ByVal Index As Integer)
        MustOverride Function DoClone(ByVal srcIndex As Integer) As Integer
        MustOverride Sub DoDelete(ByVal srcIndex As Integer)
    End Class
    Private Class Invoker(Of T As IDoSomething)
        Inherits InvokerBase
        Shared myInstances(15) As T, numUsedInstances As Integer
        Shared myDeleted(15) As Integer, numDeleted As Integer
        Public Shared HolderInstance As New Invoker(Of T)
        Overrides Sub DoDoSomething(ByVal index As Integer)
            myInstances(index).Dosomething()
        End Sub
        Private Shared Function GetNewIndex() As Integer
            If numDeleted > 0 Then
                numDeleted -= 1
                Return myDeleted(numDeleted)
            Else
                If numUsedInstances >= myInstances.Length Then
                    ReDim Preserve myInstances(myInstances.Length * 2 - 1)
                End If
                numUsedInstances += 1
                Return numUsedInstances - 1
            End If
        End Function
        Public Shared Function DoAdd(ByVal value As T) As Integer
            Dim newIndex As Integer = GetNewIndex()
            myInstances(newIndex) = value
            Return newIndex
        End Function
        Public Overrides Sub DoDelete(ByVal srcIndex As Integer)
            If numDeleted >= myDeleted.Length Then
                ReDim Preserve myDeleted(myDeleted.Length * 2 - 1)
            End If
            myDeleted(numDeleted) = srcIndex
            numDeleted += 1
        End Sub
        Public Overrides Function DoClone(ByVal srcIndex As Integer) As Integer
            Dim newIndex As Integer = GetNewIndex()
            myInstances(newIndex) = myInstances(srcIndex)
            Return newIndex
        End Function
    End Class
    ' Note: Calling Dispose on a MagicInvoker will cause all copies of it to become invalid; attempting
    '       to use or Dispose one will cause Undefined Behavior.  Conversely, abandoning the last copy of
    '       a MagicInvoker will cause a memory leak.
    Public Sub Dispose() Implements System.IDisposable.Dispose
        If holder IsNot Nothing Then
            holder.DoDelete(index)
            holder = Nothing
        End If
    End Sub
End Structure
