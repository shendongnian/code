    Private Sub ResortToolStripItemCollection(coll As ToolStripItemCollection)
        Dim oAList As New System.Collections.ArrayList(coll)
        oAList.Sort(new ToolStripItemComparer())
        coll.Clear()
        For Each oItem As ToolStripItem In oAList
            coll.Add(oItem)
        Next
    End Sub
    Private Class ToolStripItemComparer Implements System.Collections.IComparer
	    Public Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
		    Dim oItem1 As ToolStripItem = DirectCast(x, ToolStripItem)
		    Dim oItem2 As ToolStripItem = DirectCast(y, ToolStripItem)
		    Return String.Compare(oItem1.Text,oItem2.Text,True)
	    End Function
    End Class
