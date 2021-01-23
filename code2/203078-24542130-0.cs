    	Private Sub lst_Images_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_Images.DoubleClick
			Dim fIndex As Integer = Me.lst_Images.SelectedIndices(0)
			' Undo the changing of the checkbox's state by the double click event. 
			lst_Images.Items(fIndex).Checked = Not lst_Images.Items(fIndex).Checked
			' Call the viewer form
			Dim fViewer As New Image_Edit(fIndex)
			fViewer.ShowDialog()
			fViewer.Dispose()
	End Sub
