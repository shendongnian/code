    Class MainWindow
        Private Sub MainWindow_OnLoaded(sender As Object, e As RoutedEventArgs)
    
            Dim openCmdBinding As New CommandBinding(
                ApplicationCommands.Open, Sub(o, args) MyCommands.MyCommandExecute())
    
            Me.CommandBindings.Add(openCmdBinding)
    
        End Sub
    End Class
    
    Public Class MyCommands
    
        Public Shared Sub MyCommandExecute()
            MessageBox.Show("test")
        End Sub
    
    End Class
