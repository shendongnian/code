    Private Sub DisplayPackageSubTree()
      trvEntries.Nodes.Clear()
      trvEntries.SelectedNode = trvEntries.Nodes.Add("Node0", "Root Node", -1, -1)
      DisplayFolderTree(_folderContents, trvEntries.Nodes(0))
      trvEntries.ExpandAll()
      trvEntries.SelectedNode = trvEntries.Nodes(0)
      trvEntries.Refresh()
    End Sub
    Private Sub DisplayFolderTree(ByVal folderContents As SubFolder, ByRef folderNode As TreeNode)
      For Each entry As SubEntry In folderContents.Contents
        If TypeOf entry Is SubFolder Then
          Dim newNode As TreeNode = folderNode.Nodes.Add(entry.Name, entry.Name, 0, 0)
          DisplayFolderTree(entry, newNode)
        ElseIf TypeOf entry Is SubDocument Then
          folderNode.Nodes.Add(entry.Name, entry.Name, 1, 1)
        End If
      Next
    End Sub
