    Private Const REMINDER_SUBJECT As String = "CHECKEMAILREMINDER"
    
    Private Sub Application_Reminder(ByVal Item As Object)
      Dim oTask As Outlook.TaskItem
        If TypeOf Item Is Outlook.TaskItem Then
            Set oTask = Item
           
            If oTask.Subject = REMINDER_SUBJECT Then
           
                oTask.ReminderTime = DateAdd("m", 1, Now)
                oTask.Save
           
            End If
        End If
    End Sub
