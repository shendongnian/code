    Dim newGrid As New MultiCollOrder
    newGrid.Columns.Add("col_1", "col_1")
    newGrid.Columns.Add("col_2", "col_2")
    newGrid.Columns.Add("col_3", "col_3")
    newGrid.Columns.Add("col_4", "col_4")
    newGrid.Columns.Add("col_5", "col_5")
    newGrid.Rows.Add({"1", "2", "3", "4", "5"})
    newGrid.Rows.Add({"1a", "2a", "3a", "4a", "5a"})
    newGrid.Rows.Add({"1b", "2b", "3b", "4b", "5b"})
    newGrid.AllowUserToOrderColumns = True
    Me.Controls.Add(newGrid)
    newGrid.Dock = Windows.Forms.DockStyle.Fill
    Public Class MultiCollOrder
      Inherits System.Windows.Forms.DataGridView
      Private _NewOrder As List(Of Integer) 'New Order
      Private _orgSelectedOrder As New List(Of Integer) 'orginal order
      Protected Overrides Sub OnCellClick(e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
          'for rows
          Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
          For Each ecol As DataGridViewColumn In Me.Columns
            ecol.SortMode = DataGridViewColumnSortMode.Automatic
          Next
        Else
          'for column
          _orgSelectedOrder.Clear() '
          For Each ecol As DataGridViewColumn In (From esor As DataGridViewColumn In Me.SelectedColumns Order By esor.DisplayIndex Ascending)
            _orgSelectedOrder.Add(ecol.Index)
          Next
        End If
        MyBase.OnCellClick(e)
      End Sub
      Protected Overrides Sub OnColumnHeaderMouseClick(e As DataGridViewCellMouseEventArgs)
        For Each ecol As DataGridViewColumn In Me.Columns
          ecol.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
        Me.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect
        MyBase.OnColumnHeaderMouseClick(e)
      End Sub
      Protected Overrides Sub OnColumnDisplayIndexChanged(e As DataGridViewColumnEventArgs)
        If Me.SelectedColumns.Count > 1 And e.Column.Selected And _NewOrder Is Nothing Then
          _NewOrder = New List(Of Integer)
          For Each ec As DataGridViewColumn In (From esor As DataGridViewColumn In Me.Columns Order By esor.DisplayIndex Ascending)
            If ec.Index = e.Column.Index Then
              For Each esc In _orgSelectedOrder
                _NewOrder.Add(esc)
              Next
            Else
              If ec.Selected = False Then _NewOrder.Add(ec.Index)
            End If
          Next
        End If
        MyBase.OnColumnDisplayIndexChanged(e)
      End Sub
      Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Not _NewOrder Is Nothing Then ' Apply New order
          For x As Integer = 0 To _NewOrder.Count - 1
            Me.Columns(_NewOrder(x)).Selected = False
            Me.Columns(_NewOrder(x)).DisplayIndex = x
          Next
          _NewOrder = Nothing
        End If
        MyBase.OnPaint(e)
      End Sub
    End Class
