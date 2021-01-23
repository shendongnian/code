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
    ' This snippet creates a new Task in Outlook, and assigns the category.
    ' The process for categories is similar when putting them on an email instead.
    ' Some of the data here is coming from a web service call in a larger app, you can ignore that. :)
     Dim task As Outlook.TaskItem = DirectCast(Application.CreateItem(Outlook.OlItemType.olTaskItem), Outlook.TaskItem)
                    task.DueDate = Date.Parse(activity.ActDate)
                    task.StartDate = task.DueDate
                    task.Subject = String.Format(subjectText, activity.AppID)
                    task.Body = String.Format(bodyText, activity.AppID, activity.FileNum, activity.AppID)
                    task.ReminderTime = Now.AddMinutes(10)
                    task.ReminderSet = True
                    task.Categories = CATEGORY_TEST
                    task.Save()
                    task.Close(OlInspectorClose.olDiscard)
