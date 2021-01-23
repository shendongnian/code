    Public Class BigList(Of T)
        Private mInternalLists As List(Of List(Of T))
        Private mPartitionSize As Integer = 1000000
    
        Private mSize As Long = 0
    
        Public Sub New()
            mInternalLists = New List(Of List(Of T))
        End Sub
    
        Public Sub Add(Item As T)
            mSize += 1
    
            Dim PartitionIndex As Integer = CInt(mSize \ mPartitionSize)
    
            Dim Partition As List(Of T)
            If mInternalLists.Count < PartitionIndex Then
                Partition = New List(Of T)
            Else
                Partition = mInternalLists(PartitionIndex)
            End If
            Partition.Add(Item)
        End Sub
    
        Default Public ReadOnly Property Item(Index As Long) As T
            Get
                Dim PartitionIndex As Integer = CInt(mSize \ mPartitionSize)
                Dim Partition As List(Of T)
                If mInternalLists.Count < PartitionIndex Then
                    Throw New IndexOutOfRangeException
                Else
                    Partition = mInternalLists(PartitionIndex)
                End If
    
                Return Partition(CInt(mSize Mod mPartitionSize))
            End Get
        End Property
    End Class
