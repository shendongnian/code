    Public Function Browse(ByRef node As TreeNode, Optional id As Opc.ItemIdentifier = Nothing) As Integer
        Try
            Dim clone As Opc.Da.Server = your_connected_server
            Dim filters As New Opc.Da.BrowseFilters
            filters.BrowseFilter = Opc.Da.browseFilter.all
            Dim pos As Opc.Da.BrowsePosition = Nothing
            Dim elements() As Opc.Da.BrowseElement = clone.Browse(id, filters, pos)
            If (elements IsNot Nothing) Then
                For Each element As Opc.Da.BrowseElement In elements
                    Console.WriteLine(element.ItemName)
                    AddBrowseElement(node, element)
                    If (element.HasChildren = True) Then
                        id = New Opc.ItemIdentifier(element.ItemPath, element.ItemName)
                        Browse(node.Nodes.Item(node.Nodes.Count - 1), id)
                    End If
                Next
            End If
            Return 0
        Catch ex As Exception
            RaiseEvent OnException(GetCurrentMethod, ex)
            Return -1
        End Try
    End Function
    Private Sub AddBrowseElement(ByRef parent As TreeNode, element As Opc.Da.BrowseElement)
        Dim node As TreeNode = New TreeNode(element.Name)
        node.Text = element.Name
        node.Tag = element
        ' add properties
        If (element.Properties IsNot Nothing) Then
            For Each [property] As Opc.Da.ItemProperty In element.Properties
                AddItemProperty(node, [property])
            Next
        End If
        ' add to parent.
        parent.Nodes.Add(node)
    End Sub
