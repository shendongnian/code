    	Private Sub RadGrid1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.PreRender
			For Each column As GridColumn In RadGrid.Columns
				If column.UniqueName = "MyName" Then
					If column.Owner.IsItemInserted Then
						CType(column, GridTemplateColumn).ReadOnly = False 
					Else
						CType(column, GridTemplateColumn).ReadOnly = True
					End If
					Exit For
				End If
			Next
			RadGrid1.Rebind()
		End Sub
