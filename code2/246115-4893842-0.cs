    Private Shared ReadOnly CATEGORY_TEST As String = "Custom Overdue Activity"
    
    ' This method checks if our custom category exists, and creates it if it doesn't.
    Private Sub SetupCategories()
        Dim categoryList As Categories = Application.Session.Categories
        For i As Integer = 1 To categoryList.Count
            Dim c As Category = categoryList(i)
            If c.Name.Equals(CATEGORY_TEST) Then
                Return
            End If
        Next
    
        categoryList.Add(CATEGORY_TEST, Outlook.OlCategoryColor.olCategoryColorDarkOlive)
    End Sub
