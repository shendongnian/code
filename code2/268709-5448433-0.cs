    Public Sub Callback(ByVal contract As Contract) Implements IServiceCallback.Callback
        Dispatcher.BeginInvoke(
          New DispatcherOperationCallback(
              Function(arg As Object)
                  txtRequest.Text = HandleArgument(DirectCast(arg, Contract))
                  Return Nothing ' // you need to check what should be returned here '
              End Function), 
             DispatcherPriority.Normal, 
             contract)
    End Sub
